using Capstone.Domain.Entities;
using MediatR;

namespace Capstone.UseCases.Commands.UpdateTask;

public record UpdateTaskCommand(/* int Id, TaskItemDto inputTaskDto */) : IRequest<TaskItem>;