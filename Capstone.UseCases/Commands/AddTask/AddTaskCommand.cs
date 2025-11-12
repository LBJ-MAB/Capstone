using Capstone.Domain;
using MediatR;

namespace Capstone.UseCases.Commands;

public record AddTaskCommand( /* TaskItemDto taskItemDto */ ) : IRequest<TaskItem>;