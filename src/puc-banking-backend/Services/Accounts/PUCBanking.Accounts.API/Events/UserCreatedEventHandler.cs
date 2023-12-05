namespace PUCBanking.Accounts.API.Events {
    public class UserCreatedEventHandler
        : IIntegrationEventHandler<UserCreatedEvent> {

        private readonly AccountRepository _repository;
        private readonly AccountBuilder _builder;
        private readonly IEventBus _eventBus;
        public UserCreatedEventHandler(
            AccountRepository repository,
            AccountBuilder builder,
            IEventBus eventBus) {
            _repository = repository;
            _builder = builder;
            _eventBus = eventBus;
        }
        public async Task Handle(UserCreatedEvent @event) {

            var buildResult = _builder
                .CreateNew()
                .WithFirstName(@event.FirstName)
                .WithLastName(@event.LastName)
                .WithEmail(@event.Email)
                .WithInitialCardLimit(new Random().Next(500, 2000))
                .Build();

            if (buildResult.IsFailed)
                return;

            var account = buildResult.Value;
            account.Id = @event.UserId;

            await _repository.SaveAccount(account);

            _eventBus.Publish(new AccountCreatedEvent {
                AccountId = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                CardLimit = account.CardLimit
            });
        }
    }
}
