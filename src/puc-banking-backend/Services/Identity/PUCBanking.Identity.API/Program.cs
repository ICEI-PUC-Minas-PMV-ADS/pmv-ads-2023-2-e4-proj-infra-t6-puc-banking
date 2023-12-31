using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PUCBanking.Identity.API.Queries;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<IdentityOptions>(builder.Configuration);

var identityOptions = builder.Configuration.Get<IdentityOptions>();
var jwtBearerOptions = identityOptions.JwtBearer;
var eventBusOptions = identityOptions.EventBus;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserBuilder>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<TokenService>();

builder.Services.UseCommands();
builder.Services.UseQueries();

builder.Services.RegisterCommandHandler<CreateUserCommand, CreateUserCommandHandler, CreateUserCommandResult>();
builder.Services.RegisterCommandHandler<AuthenticateCommand, AuthenticateCommandHandler, AuthenticateCommandResult>();
builder.Services.RegisterQueryHandler<GetUserQuery, GetUserQueryHandler, GetUserQueryResult>();
builder.Services.RegisterQueryHandler<VerifyTokenQuery, VerifyTokenQueryHandler, VerifyTokenQueryResult>();

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

app.UseCors("CorsPolicy");
app.UseEventBus();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
