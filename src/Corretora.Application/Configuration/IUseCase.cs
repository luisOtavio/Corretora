namespace Corretora.Application.Configuration
{
    interface IUseCase<TRequest, TResponse>
    {
        TResponse Execute(TRequest requet);
    }
}
