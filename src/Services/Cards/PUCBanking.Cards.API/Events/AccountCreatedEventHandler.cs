using PUCBanking.Accounts.IntegrationEvents;
using PUCBanking.Cards.API.Models;
using PUCBanking.Cards.API.Repositories;
using PUCBanking.Shared.EventBus;

namespace PUCBanking.Cards.API.Events {
    public class AccountCreatedEventHandler
        : IIntegrationEventHandler<AccountCreatedEvent> {

        private readonly CardRepository _repository;
        public AccountCreatedEventHandler(CardRepository repository) {
            _repository = repository;
        }

        public async Task Handle(AccountCreatedEvent @event) {

            var card = CreditCard.GenerateCreditCard(@event.Username, @event.Fullname, @event.CardLimit);

            await _repository.SaveCreditCard(card);
        }
    }
}
