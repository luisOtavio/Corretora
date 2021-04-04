using System.Threading.Tasks;

namespace Corretora.Application.Configuration
{
    internal interface IUseCase<TCommand, TResponse>
    {
        Task<TResponse> Execute(TCommand command);
    }
}
