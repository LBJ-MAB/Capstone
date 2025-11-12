using Capstone.Domain.Entities;
using MediatR;

namespace Capstone.UseCases.Queries.GetIncompleteTasks;

public record GetIncompleteTasksQuery() : IRequest<List<TaskItem>>;