using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using Capstone.UseCases.Repositories;
using Capstone.UseCases.Validation;
using Capstone.UseCases.Validation.Abstractions;
using FluentValidation;
using MediatR;

namespace Capstone.UseCases.Commands.AddTask;

public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, AddTaskResult>
{
    private readonly ITaskRepository _repo;
    private readonly IAddTaskValidator _addTaskValidator;
    private readonly IMapper _mapper;
    // logger

    public AddTaskCommandHandler(ITaskRepository repo, IAddTaskValidator addTaskValidator, IMapper mapper)
    {
        _repo = repo;
        _addTaskValidator = addTaskValidator;
        _mapper = mapper;
    }

    public async Task<AddTaskResult> Handle(AddTaskCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _addTaskValidator.ValidateAsync(command.taskItemDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new AddTaskResult
            {
                Success = false,
                Errors = validationResult.ToDictionary()
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