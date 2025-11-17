using Capstone.Domain.Dtos;
using MediatR;

namespace Capstone.UseCases.Queries.GetIncompleteTasks;

public record GetIncompleteTasksQuery() : IRequest<List<TaskItemDto>?>;