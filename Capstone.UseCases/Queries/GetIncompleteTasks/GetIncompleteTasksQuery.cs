using Capstone.Domain;
using MediatR;

namespace Capstone.UseCases.Queries.GetIncompleteTasks;

public record GetIncompleteTasksQuery() : IRequest<List<TaskItem>>;