using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUCBanking.Identity.API.Commands;
using PUCBanking.Identity.API.Queries;
using PUCBanking.Shared.CQRS;

namespace PUCBanking.Identity.API.Controllers {

    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase {

        private readonly CommandHandler _commandHandler;
        private readonly QueryHandler _queryHandler;
        public UserController(CommandHandler commandHandler, QueryHandler queryHandler) {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
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
    }
}
