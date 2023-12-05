using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PUCBanking.Cards.IntegrationEvents;
using PUCBanking.Payments.API.Commands;
using PUCBanking.Payments.API.Events;
using PUCBanking.Payments.API.Queries;
using PUCBanking.Shared.EventBus.RabbitMQ;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<PaymentsOptions>(builder.Configuration);

var paymentsOptions = builder.Configuration.Get<PaymentsOptions>();
var jwtBearerOptions = paymentsOptions.JwtBearer;
var eventBusOptions = paymentsOptions.EventBus;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.UseCommands();
builder.Services.UseQueries();

builder.Services.AddScoped<TransactionRepository>();

builder.Services.RegisterCommandHandler<PayCommand, PayCommandHandler, PayCommandResult>();
builder.Services.RegisterIntegrationEvent<ConfirmationUpdatedEvent, ConfirmationUpdatedEventHandler>();
builder.Services.RegisterQueryHandler<GetTransactionQuery, GetTransactionQueryHandler, GetTransactionQueryResult>();
builder.Services.RegisterQueryHandler<GetUserTransactionsQuery, GetUserTransactionsQueryHandler, GetUserTransactionsQueryResult>();

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

builder.Services.AddDbContext<PaymentsContext>(options => {
    options
        .UseSqlServer(paymentsOptions.ConnectionString)
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
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();