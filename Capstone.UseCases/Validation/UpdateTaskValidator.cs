using Capstone.Domain.Dtos;
using Capstone.UseCases.Validation.Abstractions;
using FluentValidation;

namespace Capstone.UseCases.Validation;

public class UpdateTaskValidator : AbstractValidator<TaskItemDto>, IUpdateTaskValidator
{
    public UpdateTaskValidator()
    {
        RuleFor(t => t.Title).NotEmpty();
        RuleFor(t => t.Title).Length(1, 50);
    }
}