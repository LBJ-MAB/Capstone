using Capstone.Domain.Dtos;
using MediatR;

namespace Capstone.UseCases.Queries.GetOverdueTasks;

public record GetOverdueTasksQuery() : IRequest<List<TaskItemDto>>;