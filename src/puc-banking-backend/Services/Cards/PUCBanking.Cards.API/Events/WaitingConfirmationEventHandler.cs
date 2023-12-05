using PUCBanking.Cards.IntegrationEvents;
using PUCBanking.Payments.IntegrationEvents;

namespace PUCBanking.Cards.API.Events {
    public class WaitingConfirmationEventHandler
        : IIntegrationEventHandler<WaitingConfirmationEvent> {

        private readonly CardRepository _repository;
        private readonly IEventBus _eventBus;
        public WaitingConfirmationEventHandler(CardRepository repository, IEventBus eventBus) {
            _repository = repository;
            _eventBus = eventBus;
        }
        public async Task Handle(WaitingConfirmationEvent @event) {

            var card = await _repository
                .FindUserCreditCard(@event.CardNumber);

            if (card is null) {
                _eventBus.Publish(new ConfirmationUpdatedEvent {
                    Status = ConfirmationUpdatedEvent.ConfirmationStatus.CardNotFound,
                    TransactionId = @event.TransactionId
                });

                return;
            }

            if (!ValidCardExpires(card, @event.CardExpires) ||
                !ValidCVV(card, @event.CardCVV)) {
                _eventBus.Publish(new ConfirmationUpdatedEvent {
                    Status = ConfirmationUpdatedEvent.ConfirmationStatus.InvalidInformations,
                    TransactionId = @event.TransactionId
                });

                return;
            }

            if (card.AvailableCreditLimit < @event.Value) {
                _eventBus.Publish(new ConfirmationUpdatedEvent {
                    Status = ConfirmationUpdatedEvent.ConfirmationStatus.WithoutCreditLimit,
                    TransactionId = @event.TransactionId
                });

                return;
            }

            _eventBus.Publish(new ConfirmationUpdatedEvent {
                Status = ConfirmationUpdatedEvent.ConfirmationStatus.Confirmed,
                TransactionId = @event.TransactionId,
                UserEmail = card.UserEmail
            });
        }
        private bool ValidCardExpires(CreditCard card, DateTime value) {
            if (card.ExpiresOn.Year == value.Year &&
                card.ExpiresOn.Month == value.Month) {
                return true;
            }

            return false;
        }
        private bool ValidCVV(CreditCard card, int CVV) {
            if (card.CVV == CVV)
                return true;

            return false;
        }
    }
}
