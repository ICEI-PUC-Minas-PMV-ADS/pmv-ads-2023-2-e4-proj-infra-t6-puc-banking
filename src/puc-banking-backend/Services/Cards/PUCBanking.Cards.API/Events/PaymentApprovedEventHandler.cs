using PUCBanking.Payments.IntegrationEvents;

namespace PUCBanking.Cards.API.Events {
    public class PaymentApprovedEventHandler
        : IIntegrationEventHandler<PaymentApprovedEvent> {

        private readonly CardRepository _cardRepository;
        public PaymentApprovedEventHandler(CardRepository cardRepository) {
            _cardRepository = cardRepository;
        }
        public async Task Handle(PaymentApprovedEvent @event) {

            var card = await _cardRepository.FindUserCreditCard(@event.UserEmail);

            card.AvailableCreditLimit -= @event.Value;

            await _cardRepository.SaveChanges();
        }
    }
}
