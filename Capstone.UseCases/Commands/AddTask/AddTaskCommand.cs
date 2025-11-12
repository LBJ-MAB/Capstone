using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using MediatR;

namespace Capstone.UseCases.Commands.AddTask;

public record AddTaskCommand( TaskItemDto taskItemDto ) : IRequest<AddTaskResult>;