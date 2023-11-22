using PUCBanking.Identity.API.Repositories;
using PUCBanking.Shared.CQRS;

namespace PUCBanking.Identity.API.Queries {
    public class GetUserQueryHandler
        : IQueryHandler<GetUserQuery, GetUserQueryResult> {

        private readonly UserRepository _repository;
        public GetUserQueryHandler(UserRepository repository) {
            _repository = repository;
        }

        public async Task<GetUserQueryResult> Handle(GetUserQuery query) {

            var user = await _repository.FindUser(query.Email);

            if (user is null)
                return null;

            return new GetUserQueryResult {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Status = user.Status,
            };
        }
    }
}
