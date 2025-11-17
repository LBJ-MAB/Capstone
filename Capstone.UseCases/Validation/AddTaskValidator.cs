using Capstone.Domain.Dtos;
using FluentValidation;

namespace Capstone.UseCases.Validation;

public class AddTaskValidator : AbstractValidator<TaskItemDto>
{
    public AddTaskValidator()
    {
        RuleFor(t => t.Title).NotEmpty();
        RuleFor(t => t.Title).Length(1, 50);
        RuleFor(t => t.IsComplete).Equal(false);
    }
}