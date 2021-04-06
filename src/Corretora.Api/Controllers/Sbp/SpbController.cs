using Corretora.Application.Accounts.Deposit;
using Corretora.Application.Configuration;
using Corretora.Application.Configuration.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Corretora.Api.Controllers.Sbp
{
    [ApiController]
    [Route("api/sbp")]
    public class SpbController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;

        public SpbController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("events")]
        public async Task<CommandResult> NewEvent([FromBody] NewSbpEventRequest request)
        {
            var command = new NewDepositCommand
            {
                Amount = request.Amount,
                Origin = new OriginDto
                {
                    Bank = request?.Origin.Bank,
                    Branch = request?.Origin.Branch,
                    Cpf = request?.Origin.Cpf
                },
                Target = new TargetDto
                {
                    Bank = request?.Target.Bank,
                    Branch = request?.Target.Branch,
                    Account = request?.Target.Account
                },
            };

            return await _mediator.SendCommand(command);
        }
    }
}
