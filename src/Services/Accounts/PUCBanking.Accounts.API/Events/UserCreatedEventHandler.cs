using PUCBanking.Accounts.API.Models;
using PUCBanking.Accounts.API.Repositories;
using PUCBanking.Accounts.IntegrationEvents;
using PUCBanking.Identity.IntegrationEvents;
using PUCBanking.Shared.EventBus;

namespace PUCBanking.Accounts.API.Events {
    public class UserCreatedEventHandler
        : IIntegrationEventHandler<UserCreatedEvent> {

        private readonly AccountRepository _repository;
        private readonly IEventBus _eventBus;
        public UserCreatedEventHandler(
            AccountRepository repository,
            IEventBus eventBus) {
            _repository = repository;
            _eventBus = eventBus;
        }
        public async Task Handle(UserCreatedEvent @event) {

            var account = Account
                .CreateAccountForNewUser(@event.Id, @event.Email);
            
            await _repository.SaveAccount(account);

            _eventBus.Publish(new AccountCreatedEvent {
                AccountId = account.Id,
                CardLimit = account.CardLimit,
                Username = account.Username,
                Fullname = @event.Name
            });
        }
    }
}
