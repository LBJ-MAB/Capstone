using Capstone.Domain.Entities;
using FluentValidation.Results;

namespace Capstone.UseCases.Commands.AddTask;

public class AddTaskResult
{
    public bool Success { get; set; }
    public TaskItem? TaskItem { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }
}