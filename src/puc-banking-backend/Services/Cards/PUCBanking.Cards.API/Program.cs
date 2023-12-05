using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PUCBanking.Cards.API.Events;
using PUCBanking.Cards.API.Queries;
using PUCBanking.Payments.IntegrationEvents;
using PUCBanking.Shared.CQRS;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<CardsOptions>(builder.Configuration);

var cardsOptions = builder.Configuration.Get<CardsOptions>();
var jwtBearerOptions = cardsOptions.JwtBearer;
var eventBusOptions = cardsOptions.EventBus;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CardRepository>();
builder.Services.AddScoped<CreditCardBuilder>();

builder.Services.UseCommands();
builder.Services.UseQueries();

builder.Services.RegisterIntegrationEvent<AccountCreatedEvent, AccountCreatedEventHandler>();
builder.Services.RegisterIntegrationEvent<PaymentApprovedEvent, PaymentApprovedEventHandler>();
builder.Services.RegisterIntegrationEvent<WaitingConfirmationEvent, WaitingConfirmationEventHandler>();
builder.Services.RegisterQueryHandler<GetCreditCardQuery, GetCreditCardQueryHandler, GetCreditCardQueryResult>();

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

builder.Services.UseRabbitMQEventBus(options => {
    options.SubscriptionClientName = eventBusOptions.SubscriptionClientName;
    options.RetryCount = eventBusOptions.RetryCount;
    options.ConnectionString = eventBusOptions.ConnectionString;
    options.BrokenName = eventBusOptions.BrokenName;
});


builder.Services.AddDbContext<CardContext>(options => {
    options
        .UseSqlServer(cardsOptions.ConnectionString)
        .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
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
