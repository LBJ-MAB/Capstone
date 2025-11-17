using Capstone.Domain.Dtos;
using MediatR;

namespace Capstone.UseCases.Queries.GetCompleteTasks;

public record GetCompleteTasksQuery() : IRequest<List<TaskItemDto>?>;