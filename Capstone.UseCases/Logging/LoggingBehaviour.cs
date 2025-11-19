using MediatR;
using Microsoft.Extensions.Logging;

namespace Capstone.UseCases.Logging;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    private readonly ICorrelationIdAccessor _correlationIdAccessor;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger,
        ICorrelationIdAccessor correlationIdAccessor)
    {
        _logger = logger;
        _correlationIdAccessor = correlationIdAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var correlationId = _correlationIdAccessor.CorrelationId;
        _logger.LogInformation($"Correlation ID : {correlationId} - Processing request of type {typeof(TRequest).Name}");

        var response = await next();

        _logger.LogInformation($"Correlation ID : {correlationId} - Completed handling request, response type : {typeof(TResponse).Name}");

        return response;
    }
}