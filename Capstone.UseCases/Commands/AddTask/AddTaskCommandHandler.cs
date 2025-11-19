using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using Capstone.UseCases.Repositories;
using Capstone.UseCases.Validation;
using FluentValidation;
using MediatR;

namespace Capstone.UseCases.Commands.AddTask;

public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, AddTaskResult>
{
    private readonly ITaskRepository _repo;
    private readonly AddTaskValidator _addTaskValidator;
    private readonly IMapper _mapper;
    // logger

    public AddTaskCommandHandler(ITaskRepository repo, IEnumerable<IValidator<TaskItemDto>> validators, IMapper mapper)
    {
        _repo = repo;
        _addTaskValidator = validators.OfType<AddTaskValidator>().First();
        _mapper = mapper;
    }

    public async Task<AddTaskResult> Handle(AddTaskCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _addTaskValidator.ValidateAsync(command.taskItemDto);
        if (!validationResult.IsValid)
        {
            return new AddTaskResult
            {
                Success = false,
                Errors = validationResult.ToDictionary()
            };
        }

        var taskItem = _mapper.Map<TaskItem>(command.taskItemDto);
        taskItem.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
        
        await _repo.AddTaskAsync(taskItem);

        return new AddTaskResult
        {
            Success = true,
            TaskItem = taskItem
        };
    }
}