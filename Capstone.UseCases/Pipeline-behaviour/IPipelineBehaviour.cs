using MediatR;

namespace Capstone.UseCases.Pipeline_behaviour;

public interface IPipelineBehaviour<TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next);
}