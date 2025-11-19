using Microsoft.AspNetCore.Http;

namespace Capstone.UseCases.Logging;

public class CorrelationIdAccessor : ICorrelationIdAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CorrelationIdAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string CorrelationId => _httpContextAccessor.HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString();
}