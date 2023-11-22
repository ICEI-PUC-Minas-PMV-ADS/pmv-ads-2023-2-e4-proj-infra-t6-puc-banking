using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PUCBanking.Identity.API.Commands;
using PUCBanking.Identity.API.Infrastructure;
using PUCBanking.Identity.API.Queries;
using PUCBanking.Identity.API.Repositories;
using PUCBanking.Identity.API.Services;
using PUCBanking.Identity.IntegrationEvents;
using PUCBanking.Shared.CQRS;
using PUCBanking.Shared.EventBus;
using PUCBanking.Shared.EventBus.RabbitMQ;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<IdentityOptions>(builder.Configuration);
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<UserRepository>();

builder.Services.UseCommands();
builder.Services.UseQueries();

builder.Services.RegisterCommandHandler<CreateUserCommand, CreateUserCommandHandler, CreateUserCommandResult>();
builder.Services.RegisterCommandHandler<AuthenticateCommand, AuthenticateCommandHandler, AuthenticateCommandResult>();
builder.Services.RegisterQueryHandler<GetUserQuery, GetUserQueryHandler, GetUserQueryResult>();
builder.Services.RegisterQueryHandler<VerifyTokenQuery, VerifyTokenQueryHandler, VerifyTokenQueryResult>();

var identityOptions = builder.Configuration.Get<IdentityOptions>();
var jwtBearerOptions = identityOptions.JwtBearer;
var eventBusOptions = identityOptions.EventBus;

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt => {
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtBearerOptions.SecretKey)),
        ValidateIssuer = jwtBearerOptions.ValidateIssuer,
        ValidIssuer = jwtBearerOptions.Issuer,
        ValidateAudience = jwtBearerOptions.ValidateAudience,
        ValidAudience = jwtBearerOptions.Audience,
    };
});

builder.Services.AddDbContext<IdentityContext>(options => {
    options
        .UseSqlServer(identityOptions.ConnectionString)
        .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});

builder.Services.UseRabbitMQEventBus(options => {
    options.SubscriptionClientName = eventBusOptions.SubscriptionClientName;
    options.RetryCount = eventBusOptions.RetryCount;
    options.ConnectionString = eventBusOptions.ConnectionString;
    options.BrokenName = eventBusOptions.BrokenName;
});

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEventBus();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
