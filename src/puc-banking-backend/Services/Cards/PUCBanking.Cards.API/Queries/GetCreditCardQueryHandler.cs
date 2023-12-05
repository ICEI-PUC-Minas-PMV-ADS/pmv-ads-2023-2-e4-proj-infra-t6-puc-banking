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
                .FindUserCreditCard(query.UserEmail);

            if (creditCard is null)
                return null;

            return new GetCreditCardQueryResult {
                Id = creditCard.Id,
                AvailableCreditLimit = creditCard.AvailableCreditLimit,
                CreatedOn = creditCard.CreatedOn,
                CreditLimit = creditCard.CreditLimit,
                CVV = creditCard.CVV,
                ExpiresOn = creditCard.ExpiresOn,
                HolderName = creditCard.HolderName,
                Number = creditCard.Number,
                UserEmail = creditCard.UserEmail,
            };
        }
    }
}
