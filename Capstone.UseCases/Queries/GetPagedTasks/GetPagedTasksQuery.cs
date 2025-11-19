using Capstone.Domain.Dtos;
using MediatR;

namespace Capstone.UseCases.Queries.GetPagedTasks;

public record GetPagedTasksQuery(int PageNumber, int TasksPerPage) : IRequest<List<TaskItemDto>?>;