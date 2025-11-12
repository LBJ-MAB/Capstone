using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using Capstone.UseCases.Repositories;
using FluentValidation;
using MediatR;

namespace Capstone.UseCases.Commands.AddTask;

public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, AddTaskResult>
{
    private readonly ITaskRepository _repo;
    private readonly IValidator<TaskItemDto> _validator;
    private readonly IMapper _mapper;
    // logger

    public AddTaskCommandHandler(ITaskRepository repo, IValidator<TaskItemDto> validator)
    {
        _repo = repo;
        _validator = validator;
    }

    public async Task<AddTaskResult> Handle(AddTaskCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command.taskItemDto);
        if (!validationResult.IsValid)
        {
            return new AddTaskResult
            {
                Success = false,
                Errors = validationResult.Errors
            };
        }

        var taskItem = _mapper.Map<TaskItem>(command.taskItemDto);
        taskItem.CreatedAt = DateTime.UtcNow;
        
        await _repo.AddTaskAsync(taskItem);

        return new AddTaskResult
        {
            Success = true,
            TaskItem = taskItem
        };
    }
}