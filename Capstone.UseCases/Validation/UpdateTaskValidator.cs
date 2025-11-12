using Capstone.Domain.Dtos;
using FluentValidation;

namespace Capstone.UseCases.Validation;

public class UpdateTaskValidator : AbstractValidator<TaskItemDto>
{
    public UpdateTaskValidator()
    {
        RuleFor(t => t.Title).NotEmpty();
        RuleFor(t => t.Title).Length(1, 50);
    }
}