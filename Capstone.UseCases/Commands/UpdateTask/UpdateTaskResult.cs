using Capstone.Domain.Entities;

namespace Capstone.UseCases.Commands.UpdateTask;

public class UpdateTaskResult
{
    public bool Success;
    public bool? NotFound;
    public bool? NotValid;
    public IDictionary<string, string[]>? Errors;
}