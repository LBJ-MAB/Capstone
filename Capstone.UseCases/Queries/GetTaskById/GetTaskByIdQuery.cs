using Capstone.Domain.Dtos;
using MediatR;

namespace Capstone.UseCases.Queries.GetTaskById;

public record GetTaskByIdQuery(int Id) : IRequest<List<TaskItemDto>>;