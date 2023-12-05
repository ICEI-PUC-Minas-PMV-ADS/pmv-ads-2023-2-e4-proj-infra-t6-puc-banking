using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PUCBanking.Accounts.API.Builders;
using PUCBanking.Accounts.API.Events;
using PUCBanking.Accounts.API.Queries;
using PUCBanking.Shared.CQRS;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AccountsOptions>(builder.Configuration);

var accountsOptions = builder.Configuration.Get<AccountsOptions>();
var jwtBearerOptions = accountsOptions.JwtBearer;
var eventBusOptions = accountsOptions.EventBus;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<AccountBuilder>();

builder.Services.UseQueries();
builder.Services.UseCommands();

builder.Services.RegisterIntegrationEvent<UserCreatedEvent, UserCreatedEventHandler>();
builder.Services.RegisterQueryHandler<GetAccountQuery, GetAccountQueryHandler, GetAccountQueryResult>();

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


builder.Services.AddDbContext<AccountsContext>(options => {
    options
        .UseSqlServer(accountsOptions.ConnectionString)
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
