using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using MediatR;

namespace Capstone.UseCases.Commands.UpdateTask;

public record UpdateTaskCommand(int Id, TaskItemDto taskItemDto) : IRequest<UpdateTaskResult>;