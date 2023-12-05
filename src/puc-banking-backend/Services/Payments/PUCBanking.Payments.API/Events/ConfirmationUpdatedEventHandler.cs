using Microsoft.EntityFrameworkCore;
using PUCBanking.Cards.IntegrationEvents;
using PUCBanking.Payments.IntegrationEvents;

namespace PUCBanking.Payments.API.Events {
    public class ConfirmationUpdatedEventHandler
        : IIntegrationEventHandler<ConfirmationUpdatedEvent> {

        private readonly TransactionRepository _repository;
        private readonly IEventBus _eventBus;
        public ConfirmationUpdatedEventHandler(TransactionRepository repository, IEventBus eventBus) {
            _repository = repository;
            _eventBus = eventBus;
        }
        public async Task Handle(ConfirmationUpdatedEvent @event) {

            var transaction = await _repository.GetTransaction(@event.TransactionId);

            if (@event.Status is not ConfirmationUpdatedEvent.ConfirmationStatus.Confirmed) {
                transaction.Status = TransactionStatus.Reproved;
                await _repository.SaveChanges();
                return;
            }

            transaction.UserEmail = @event.UserEmail;
            transaction.Status = TransactionStatus.Approved;

            _eventBus.Publish(new PaymentApprovedEvent {
                TransactionId = transaction.Id,
                UserEmail = transaction.UserEmail,
                Value = transaction.Value
            });

            await _repository.SaveChanges();
        }
    }
}
