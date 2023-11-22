using PUCBanking.Identity.API.Repositories;
using PUCBanking.Identity.API.Services;
using PUCBanking.Identity.IntegrationEvents;
using PUCBanking.Shared.CQRS;
using PUCBanking.Shared.EventBus;

namespace PUCBanking.Identity.API.Commands {
    public class CreateUserCommandHandler
        : ICommandHandler<CreateUserCommand, CreateUserCommandResult> {

        private readonly UserRepository _repository;
        private readonly PasswordService _passwordService;
        private readonly IEventBus _eventBus;
        public CreateUserCommandHandler(
            UserRepository repository,
            PasswordService passwordService,
            IEventBus eventBus) {
            _repository = repository;
            _passwordService = passwordService;
            _eventBus = eventBus;
        }

        public async Task<CreateUserCommandResult> Handle(CreateUserCommand command) {
            
            if (await _repository.FindUser(command.Email) is not null) {
                return new CreateUserCommandResult {
                    Message = "Usuário já cadastrado.",
                    Status = CreateUserCommandStatus.UserAlreadyExists
                };
            }

            var user = User.CreateCustomer(
                command.Name,
                command.Email,
                _passwordService.EncryptPassword(command.Password));

            await _repository.AddUser(user);

            _eventBus.Publish(new UserCreatedEvent {
                Name = user.Name,
                Email = user.Email
            });

            return new CreateUserCommandResult {
                Id = user.Id,
                Message = "Usuário cadastrado.",
                Status = CreateUserCommandStatus.UserCreated
            };
        }
    }
}
