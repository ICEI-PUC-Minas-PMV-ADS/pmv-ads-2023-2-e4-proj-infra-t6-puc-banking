using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUCBanking.Identity.API.Queries;

namespace PUCBanking.Identity.API.Controllers {

    [ApiController]
    [Route("v1/identity")]
    public class IdentityController : ControllerBase {

        private readonly CommandHandler _commandHandler;
        private readonly QueryHandler _queryHandler;
        public IdentityController(CommandHandler commandHandler, QueryHandler queryHandler) {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand command) {

            var commandResult = await _commandHandler
                .Handle<AuthenticateCommand, AuthenticateCommandResult>(command);

            if (commandResult.Status is not AuthenticateCommandStatus.UserAuthenticated) {
                return Unauthorized(commandResult);
            }

            return Ok(commandResult);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command) {

            var commandResult = await _commandHandler
                .Handle<CreateUserCommand, CreateUserCommandResult>(command);

            if (commandResult.Status is not CreateUserCommandResult.CommandResultStatus.UserCreated) {
                return BadRequest(commandResult);
            }

            return Ok(commandResult);
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public async Task<IActionResult> Authenticated() {

            var userEmail = User.Identity?.Name;

            if (string.IsNullOrEmpty(userEmail)) {
                return NotFound();
            }

            var query = new GetUserQuery { Email = userEmail };
            var queryResult = await _queryHandler
                .Handle<GetUserQuery, GetUserQueryResult>(query);

            if (queryResult is null) {
                return NotFound();
            }

            return Ok(queryResult);
        }

        [HttpGet]
        [Route("verify")]
        public async Task<IActionResult> Verify(string token, string username) {

            var query = new VerifyTokenQuery { Token = token, Username = username };
            var queryResult = await _queryHandler.Handle<VerifyTokenQuery, VerifyTokenQueryResult>(query);

            return Ok(queryResult);
        }
    }
}
