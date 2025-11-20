using Capstone.Domain.Dtos;
using FluentValidation.Results;

namespace Capstone.UseCases.Validation.Abstractions;

public interface IAddTaskValidator
{
    Task<ValidationResult> ValidateAsync(TaskItemDto dto, CancellationToken cancellationToken);
}