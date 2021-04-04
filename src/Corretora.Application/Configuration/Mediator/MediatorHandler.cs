using MediatR;
using System.Threading.Tasks;

namespace Corretora.Application.Configuration.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult> SendCommand<T>(T comando) where T : IRequest<CommandResult>
        {
            return await _mediator.Send(comando);
        }

        //public async Task PublicarEvento<T>(T evento) where T : Event
        //{
        //    await _mediator.Publish(evento);
        //}
    }
}
