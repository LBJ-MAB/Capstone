using Capstone.Domain.Entities;
using MediatR;

namespace Capstone.UseCases.Commands;

public record AddTaskCommand( /* TaskItemDto taskItemDto */ ) : IRequest<TaskItem>;