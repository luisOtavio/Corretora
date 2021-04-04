using MediatR;
using System.Threading.Tasks;

namespace Corretora.Application.Configuration.Mediator
{
    public interface IMediatorHandler
    {
        Task<CommandResult> SendCommand<T>(T comando) where T : IRequest<CommandResult>;

    }
}
