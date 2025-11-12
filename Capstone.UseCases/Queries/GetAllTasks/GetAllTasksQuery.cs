using Capstone.Domain.Dtos;
using MediatR;

namespace Capstone.UseCases.Queries.GetAllTasks;

public record GetAllTasksQuery() : IRequest<List<TaskItemDto>?>;