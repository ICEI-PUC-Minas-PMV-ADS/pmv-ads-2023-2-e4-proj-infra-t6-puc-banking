using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUCBanking.Payments.API.Commands;
using PUCBanking.Payments.API.Queries;

namespace PUCBanking.Payments.API.Controllers {

    [ApiController]
    [Route("v1/payments")]
    public class PaymentsController : ControllerBase {

        private readonly CommandHandler _commandHandler;
        private readonly QueryHandler _queryHandler;
        public PaymentsController(CommandHandler commandHandler, QueryHandler queryHandler) {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> Pay([FromBody]PayCommand command) {

            var commandResult = await _commandHandler
                .Handle<PayCommand, PayCommandResult>(command);

            return Ok(commandResult);
        }

        [HttpGet]
        [Route("check")]
        public async Task<IActionResult> Check(Guid transactionId) {

            var query = new GetTransactionQuery { TransactionId = transactionId };
            var queryResult = await _queryHandler
                .Handle<GetTransactionQuery, GetTransactionQueryResult>(query);

            if (queryResult is null) {
                return NotFound();
            }

            return Ok(queryResult);
        }

        [HttpGet]
        [Route("transactions")]
        [Authorize]
        public async Task<IActionResult> Transactions() {

            var query = new GetUserTransactionsQuery { UserEmail = User.Identity.Name };
            var queryResult = await _queryHandler
                .Handle<GetUserTransactionsQuery, GetUserTransactionsQueryResult>(query);

            return Ok(queryResult);
        }
    }
}
