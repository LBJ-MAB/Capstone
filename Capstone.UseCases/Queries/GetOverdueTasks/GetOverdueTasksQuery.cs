using Capstone.Domain;
using MediatR;

namespace Capstone.UseCases.Queries.GetOverdueTasks;

public record GetOverdueTasksQuery() : IRequest<List<TaskItem>>;