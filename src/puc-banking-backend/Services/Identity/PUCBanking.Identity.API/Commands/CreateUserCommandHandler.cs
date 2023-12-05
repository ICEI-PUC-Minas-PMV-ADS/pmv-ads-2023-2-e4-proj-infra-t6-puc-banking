namespace PUCBanking.Identity.API.Commands {
    public class CreateUserCommandHandler
        : ICommandHandler<CreateUserCommand, CreateUserCommandResult> {

        private readonly UserBuilder _builder;
        private readonly UserRepository _repository;
        private readonly IEventBus _eventBus;
        public CreateUserCommandHandler(UserBuilder builder, UserRepository repository, IEventBus eventBus) {
            _builder = builder;
            _repository = repository;
            _eventBus = eventBus;
        }
        public async Task<CreateUserCommandResult> Handle(CreateUserCommand command) {

            if (command is null) {
                throw new ArgumentNullException(nameof(command));
            }

            var buildUserResult = _builder
                .CreateNew()
                .WithFirstName(command.FirstName)
                .WithLastName(command.LastName)
                .WithEmail(command.Email)
                .WithPassword(command.Password)
                .EncryptPassword()
                .Build();

            if (buildUserResult.IsFailed) {
                return new CreateUserCommandResult {
                    Message = buildUserResult.Errors.ToString(),
                    Status = CreateUserCommandResult.CommandResultStatus.Error
                };
            }

            var user = buildUserResult.Value;

            if (await _repository
                .FindUser(user.Email) is not null) {
                return new CreateUserCommandResult {
                    Message = "Usuário já existe.",
                    Status = CreateUserCommandResult.CommandResultStatus.UserAlreadyExists
                };
            }

            await _repository.AddUser(user);

            _eventBus.Publish(new UserCreatedEvent {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });

            return new CreateUserCommandResult {
                Id = user.Id,
                Message = "Usuário criado com sucesso.",
                Status = CreateUserCommandResult.CommandResultStatus.UserCreated
            };
        }
    }
}
