using PUCBanking.Payments.IntegrationEvents;
using System.Globalization;

namespace PUCBanking.Payments.API.Commands {
    public class PayCommandHandler
        : ICommandHandler<PayCommand, PayCommandResult> {

        private readonly TransactionRepository _repository;
        private readonly IEventBus _eventBus;
        public PayCommandHandler(TransactionRepository repository, IEventBus eventBus) {
            _repository = repository;
            _eventBus = eventBus;
        }

        public async Task<PayCommandResult> Handle(PayCommand command) {

            var transaction = new Transaction {
                Id = Guid.NewGuid(),
                CardCVV = command.CardCVV,
                CardExpires = DateTime.ParseExact(command.CardExpires, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                CardHolderName = command.CardHolderName,
                CardNumber = command.CardNumber,
                CreatedOn = DateTime.Now,
                Name = command.Name,
                Status = TransactionStatus.PendingOfConfirmation,
                Value = command.Value,
                UserEmail = ""
            };

            await _repository.AddTransaction(transaction);

            _eventBus.Publish(new WaitingConfirmationEvent {
                CardCVV = transaction.CardCVV,
                CardExpires = transaction.CardExpires,
                CardHolderName = transaction.CardHolderName,
                CardNumber= transaction.CardNumber,
                Name = transaction.Name,
                TransactionId = transaction.Id,
                Value = transaction.Value,
            });

            return new PayCommandResult {
                Id = transaction.Id,
                Status = transaction.Status,
            };
        }
    }
}
