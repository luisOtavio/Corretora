using Corretora.Application.Accounts.Deposit;
using Corretora.Application.Configuration;
using Corretora.Application.Configuration.Mediator;
using Corretora.Application.Sbp.Events;
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
        public async Task<CommandResult> NewEvent([FromBody] NewSbpEventCommand command)
        {
            return await _mediator.SendCommand(command);
        }
    }
}
