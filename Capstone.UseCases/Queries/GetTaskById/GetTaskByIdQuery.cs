using Capstone.Domain.Entities;
using MediatR;

namespace Capstone.UseCases.Queries.GetTaskById;

public record GetTaskByIdQuery(int Id) : IRequest<List<TaskItem>>;