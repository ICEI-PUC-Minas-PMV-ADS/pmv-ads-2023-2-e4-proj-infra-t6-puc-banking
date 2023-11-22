using Microsoft.AspNetCore.Mvc;
using PUCBanking.Identity.API.Commands;
using PUCBanking.Identity.API.Queries;
using PUCBanking.Shared.CQRS;

namespace PUCBanking.Identity.API.Controllers {

    [ApiController]
    [Route("v1/authentication")]
    public class AuthenticationController : ControllerBase {

        private readonly CommandHandler _commandHandler;
        private readonly QueryHandler _queryHandler;
        public AuthenticationController(
            CommandHandler commandHandler,
            QueryHandler queryHandler) {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        [Route("verify")]
        public async Task<IActionResult> Verify(string token, string username) {

            var query = new VerifyTokenQuery { Token = token, Username = username };
            var queryResult = await _queryHandler.Handle<VerifyTokenQuery, VerifyTokenQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateCommand command) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var commandResult = await _commandHandler
                .Handle<AuthenticateCommand, AuthenticateCommandResult>(command);

            if (commandResult.Status is AuthenticateCommandStatus.UserNotFound) {
                return Unauthorized(commandResult);
            }

            return Ok(commandResult);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var commandResult = await _commandHandler
                .Handle<CreateUserCommand, CreateUserCommandResult>(command);

            if (commandResult.Status is not CreateUserCommandStatus.UserCreated) {
                return BadRequest(commandResult);
            }

            return Ok(commandResult);
        }
    }
}
