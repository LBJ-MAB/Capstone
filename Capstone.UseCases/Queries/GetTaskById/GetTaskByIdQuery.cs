using Capstone.Domain;
using MediatR;

namespace Capstone.UseCases.Queries.GetTaskById;

public record GetTaskByIdQuery(int Id) : IRequest<List<TaskItem>>;