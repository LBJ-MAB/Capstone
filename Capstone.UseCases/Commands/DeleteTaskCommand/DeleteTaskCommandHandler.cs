using Capstone.UseCases.Repositories;
using MediatR;

namespace Capstone.UseCases.Commands.DeleteTaskCommand;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly ITaskRepository _repo;
    // logger
    
    public DeleteTaskCommandHandler(ITaskRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
    {
        var taskItem = await _repo.GetTaskByIdAsync(command.Id);
        if (taskItem is null)
        {
            return false;
        }

        await _repo.DeleteTaskAsync(taskItem);
        return true;
    }
}