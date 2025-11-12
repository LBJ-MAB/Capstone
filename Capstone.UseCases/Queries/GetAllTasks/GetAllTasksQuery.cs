using Capstone.Domain;
using MediatR;

namespace Capstone.UseCases.Queries.GetAllTasks;

public record GetAllTasksQuery() : IRequest<List<TaskItem>>;