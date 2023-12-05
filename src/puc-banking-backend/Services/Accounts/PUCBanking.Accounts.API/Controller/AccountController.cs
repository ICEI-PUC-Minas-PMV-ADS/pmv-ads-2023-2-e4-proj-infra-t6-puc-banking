using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUCBanking.Accounts.API.Queries;
using PUCBanking.Shared.CQRS;

namespace PUCBanking.Accounts.API.Controller {

    [ApiController]
    [Route("v1/accounts")]
    public class AccountController : ControllerBase {

        private readonly CommandHandler _commandHandler;
        private readonly QueryHandler _queryHandler;
        public AccountController(
            CommandHandler commandHandler,
            QueryHandler queryHandler) {

            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public async Task<IActionResult> Authenticated() {

            var username = User.Identity?.Name;

            if (string.IsNullOrEmpty(username)) {
                return NotFound();
            }

            var query = new GetAccountQuery { UserEmail = username };
            var queryResult = await _queryHandler.Handle<GetAccountQuery, GetAccountQueryResult>(query);

            if (queryResult is null)
                return NotFound();

            return Ok(queryResult);
        }
    }
}
