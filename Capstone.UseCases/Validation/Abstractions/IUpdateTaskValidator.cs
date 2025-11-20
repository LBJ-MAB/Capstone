using Capstone.Domain.Dtos;
using FluentValidation.Results;

namespace Capstone.UseCases.Validation.Abstractions;

public interface IUpdateTaskValidator
{
    Task<ValidationResult> ValidateAsync(TaskItemDto dto, CancellationToken cancellationToken);
}