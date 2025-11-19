using MediatR;
using Microsoft.Extensions.Logging;

namespace Capstone.UseCases.Logging;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Processing request of type {typeof(TRequest).Name}");

        var response = await next();

        _logger.LogInformation($"Completed handling request, response type : {typeof(TResponse).Name}");

        return response;
    }
}