using PUCBanking.Identity.API.Services;
using PUCBanking.Shared.CQRS;

namespace PUCBanking.Identity.API.Queries {
    public class VerifyTokenQueryHandler
        : IQueryHandler<VerifyTokenQuery, VerifyTokenQueryResult> {

        private readonly TokenService _tokenService;
        public VerifyTokenQueryHandler(TokenService tokenService) {
            _tokenService = tokenService;
        }

        public async Task<VerifyTokenQueryResult> Handle(VerifyTokenQuery command) {

            var isValid = _tokenService
                .ValidateToken(command.Token, command.Username);

            if (isValid == false) {
                return new VerifyTokenQueryResult {
                    IsExpired = true,
                    IsValid = true
                };
            }

            var isExpired = _tokenService.IsExpiredToken(command.Token);

            return new VerifyTokenQueryResult {
                IsExpired = isExpired,
                IsValid = isValid
            };
        }
    }
}
