using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PUCBanking.Accounts.API.Configuration;
using PUCBanking.Accounts.API.Events;
using PUCBanking.Accounts.API.Infrastructure;
using PUCBanking.Accounts.API.Queries;
using PUCBanking.Accounts.API.Repositories;
using PUCBanking.Identity.IntegrationEvents;
using PUCBanking.Shared.CQRS;
using PUCBanking.Shared.EventBus;
using PUCBanking.Shared.EventBus.RabbitMQ;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AccountsOptions>(builder.Configuration);
builder.Services.AddScoped<AccountRepository>();

builder.Services.UseCommands();
builder.Services.UseQueries();

builder.Services.RegisterQueryHandler<GetAccountQuery, GetAccountQueryHandler, GetAccountQueryResult>();
builder.Services.RegisterIntegrationEvent<UserCreatedEvent, UserCreatedEventHandler>();

var accountsOptions = builder.Configuration.Get<AccountsOptions>();
var jwtBearerOptions = accountsOptions.JwtBearer;
var eventBusOptions = accountsOptions.EventBus;

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

builder.Services.AddDbContext<AccountContext>(options => {
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
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseEventBus();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
