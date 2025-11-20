using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.UseCases.Repositories;
using Capstone.UseCases.Validation;
using FluentValidation;
using MediatR;

namespace Capstone.UseCases.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskResult>
{
    private readonly ITaskRepository _repo;
    private readonly UpdateTaskValidator _updateTaskValidator;
    // logger
    
    public UpdateTaskCommandHandler(ITaskRepository repo, UpdateTaskValidator updateTaskValidator, IMapper mapper)
    {
        _repo = repo;
        _updateTaskValidator = updateTaskValidator;
    }

    public async Task<UpdateTaskResult> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
    {
        // return updatedTaskResult
        
        var validationResult = await _updateTaskValidator.ValidateAsync(command.taskItemDto);
        if (!validationResult.IsValid)
        {
            return new UpdateTaskResult
            {
                Success = false,
                NotValid = true,
                Errors = validationResult.ToDictionary()
            };
        }

        var taskItem = await _repo.GetTaskByIdAsync(command.Id);
        if (taskItem is null)
        {
            return new UpdateTaskResult
            {
                Success = false,
                NotFound = true
            };
        }

        taskItem.Title = command.taskItemDto.Title;
        taskItem.IsComplete = command.taskItemDto.IsComplete;
        taskItem.Description = command.taskItemDto.Description;
        taskItem.Priority = command.taskItemDto.Priority;
        taskItem.DueDate = command.taskItemDto.DueDate;
        taskItem.UpdatedAt = DateTime.UtcNow;

        await _repo.SaveChangesAsync();

        return new UpdateTaskResult
        {
            Success = true
        };
    }
}