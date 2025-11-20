using Capstone.Domain.Dtos;
using Capstone.UseCases.Validation.Abstractions;
using FluentValidation;

namespace Capstone.UseCases.Validation;

public class AddTaskValidator : AbstractValidator<TaskItemDto>, IAddTaskValidator
{
    public AddTaskValidator()
    {
        RuleFor(t => t.Title).NotEmpty();
        RuleFor(t => t.Title).Length(1, 50);
        RuleFor(t => t.IsComplete).Equal(false);
    }
}