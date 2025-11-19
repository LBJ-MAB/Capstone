namespace Capstone.UseCases.Logging;

public interface ICorrelationIdAccessor
{
    string correlationId { get; }
}