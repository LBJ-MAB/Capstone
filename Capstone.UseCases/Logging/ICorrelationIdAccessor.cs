namespace Capstone.UseCases.Logging;

public interface ICorrelationIdAccessor
{
    string CorrelationId { get; }
}