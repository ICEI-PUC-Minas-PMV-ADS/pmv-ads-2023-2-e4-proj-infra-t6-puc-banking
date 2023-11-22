using PUCBanking.Cards.API.Repositories;
using PUCBanking.Shared.CQRS;

namespace PUCBanking.Cards.API.Queries {
    public class GetCreditCardQueryHandler
        : IQueryHandler<GetCreditCardQuery, GetCreditCardQueryResult> {

        private readonly CardRepository _repository; 
        public GetCreditCardQueryHandler(CardRepository repository) {
            _repository = repository;
        }

        public async Task<GetCreditCardQueryResult> Handle(GetCreditCardQuery query) {

            var creditCard = await _repository
                .FindUserCreditCard(query.Username);

            if (creditCard is null)
                return null;

            return new GetCreditCardQueryResult {
                Id = creditCard.Id,
                AvailableCreditLimit = creditCard.AvailableCreditLimit,
                BestDayToPay = creditCard.BestDayToPay,
                CreatedOn = creditCard.CreatedOn,
                ExpiresOn = creditCard.ExpiresOn,
                CreditLimit = creditCard.CreditLimit,
                HolderName = creditCard.HolderName,
                Number = creditCard.Number,
                SecurityCode = creditCard.SecurityCode,
                Username = creditCard.Username,
            };
        }
    }
}
