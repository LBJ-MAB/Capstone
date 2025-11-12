using Capstone.Domain.Entities;
using MediatR;

namespace Capstone.UseCases.Queries.GetCompleteTasks;

public record GetCompleteTasksQuery() : IRequest<List<TaskItem>>;