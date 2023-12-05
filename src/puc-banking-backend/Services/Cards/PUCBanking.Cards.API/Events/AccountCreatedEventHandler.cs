namespace PUCBanking.Cards.API.Events {
    public class AccountCreatedEventHandler
        : IIntegrationEventHandler<AccountCreatedEvent> {

        private readonly CardRepository _repository;
        private readonly CreditCardBuilder _cardBuilder;
        public AccountCreatedEventHandler(CardRepository repository, CreditCardBuilder builder) {
            _repository = repository;
            _cardBuilder = builder;
        }
        public async Task Handle(AccountCreatedEvent @event) {

            var buildCardResult = _cardBuilder
                .CreateNew()
                .WithUserEmail(@event.Email)
                .WithInitialCardLimit(@event.CardLimit)
                .WithHolderName(@event.FirstName + " " + @event.LastName)
                .Build();

            if (buildCardResult.IsFailed) {
                return;
            }

            var card = buildCardResult.Value;

            await _repository.SaveCreditCard(card);
        }
    }
}
