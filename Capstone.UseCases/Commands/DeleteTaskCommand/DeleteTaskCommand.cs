using Capstone.Domain.Entities;
using MediatR;

namespace Capstone.UseCases.Commands.DeleteTaskCommand;

public record DeleteTaskCommand(int Id) : IRequest<bool>;