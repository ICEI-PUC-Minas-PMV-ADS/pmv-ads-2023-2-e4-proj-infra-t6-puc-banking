using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUCBanking.Cards.API.Queries;
using PUCBanking.Shared.CQRS;

namespace PUCBanking.Cards.API.Controllers {

    [ApiController]
    [Route("v1/cards")]
    public class CardController : ControllerBase {

        private readonly CommandHandler _commandHandler;
        private readonly QueryHandler _queryHandler;
        public CardController(CommandHandler commandHandler, QueryHandler queryHandler) {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public async Task<IActionResult> Authenticated() {

            var username = User.Identity.Name;

            var query = new GetCreditCardQuery { Username = username };
            var queryResult = await _queryHandler.Handle<GetCreditCardQuery, GetCreditCardQueryResult>(query);

            if (queryResult is null) {
                return NotFound();
            }

            return Ok(queryResult);
        }
    }
}
