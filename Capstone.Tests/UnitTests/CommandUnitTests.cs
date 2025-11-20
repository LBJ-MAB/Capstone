using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using Capstone.UseCases.Commands.AddTask;
using Capstone.UseCases.Commands.DeleteTaskCommand;
using Capstone.UseCases.Commands.UpdateTask;
using Capstone.UseCases.Repositories;
using Capstone.UseCases.Validation;
using Capstone.UseCases.Validation.Abstractions;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace Capstone.Tests.UnitTests;

[TestFixture]
public class CommandUnitTests
{
    // mock repo, validator and mapper
    private Mock<ITaskRepository> _mockRepo;
    private Mock<IAddTaskValidator> _mockAddTaskValidator;
    private Mock<IUpdateTaskValidator> _mockUpdateTaskValidator;
    private Mock<IMapper> _mockMapper;
    
    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<ITaskRepository>();
        _mockAddTaskValidator = new Mock<IAddTaskValidator>();
        _mockUpdateTaskValidator = new Mock<IUpdateTaskValidator>();
        _mockMapper = new Mock<IMapper>();
    }

    [Test]
    public async Task AddTaskCommandHandler_ReturnsSuccessFalse_WhenValidatorReturnsFalse()
    {
        // arrange
        _mockAddTaskValidator.Setup(v => v.ValidateAsync(It.IsAny<TaskItemDto>(), CancellationToken.None))
            .ReturnsAsync(new ValidationResult([new ValidationFailure("property", "error")]));
        
        var command = new AddTaskCommand(It.IsAny<TaskItemDto>());
        var handler = new AddTaskCommandHandler(_mockRepo.Object, _mockAddTaskValidator.Object, _mockMapper.Object);
        
        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.Success.Should().Be(false);
    }

    [Test]
    public async Task AddTaskCommandHandler_ReturnsSuccessTrue_WhenValidatorReturnsTrue()
    {
        // arrange
        _mockAddTaskValidator.Setup(v => v.ValidateAsync(It.IsAny<TaskItemDto>(), CancellationToken.None))
            .ReturnsAsync(new ValidationResult());
        _mockMapper.Setup(m => m.Map<TaskItem>(It.IsAny<TaskItemDto>()))
            .Returns(new TaskItem());
        _mockRepo.Setup(r => r.AddTaskAsync(It.IsAny<TaskItem>()))
            .Returns(Task.CompletedTask);

        var command = new AddTaskCommand(new TaskItemDto());
        var handler = new AddTaskCommandHandler(_mockRepo.Object, _mockAddTaskValidator.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.Success.Should().Be(true);
    }

    [Test]
    public async Task UpdateTaskCommandHandler_ReturnsSuccessFalse_WhenValidatorReturnsFalse()
    {
        // arrange
        _mockUpdateTaskValidator.Setup(v => v.ValidateAsync(It.IsAny<TaskItemDto>(), CancellationToken.None))
            .ReturnsAsync(new ValidationResult([new ValidationFailure("property", "error")]));

        var command = new UpdateTaskCommand(It.IsAny<int>(), It.IsAny<TaskItemDto>());
        var handler =
            new UpdateTaskCommandHandler(_mockRepo.Object, _mockUpdateTaskValidator.Object);
        
        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.Success.Should().Be(false);
    }

    [Test]
    public async Task UpdateTaskCommandHandler_ReturnsNotValid_WhenValidatorReturnsFalse()
    {
        // arrange
        _mockUpdateTaskValidator.Setup(v => v.ValidateAsync(It.IsAny<TaskItemDto>(), CancellationToken.None))
            .ReturnsAsync(new ValidationResult([new ValidationFailure("property", "error")]));

        var command = new UpdateTaskCommand(It.IsAny<int>(), It.IsAny<TaskItemDto>());
        var handler =
            new UpdateTaskCommandHandler(_mockRepo.Object, _mockUpdateTaskValidator.Object);
        
        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.NotValid.Should().Be(true);
    }

    [Test]
    public async Task UpdateTaskCommandHandler_ReturnsSuccessFalse_WhenRepoReturnsNull()
    {
        // arrange
        _mockUpdateTaskValidator.Setup(v => v.ValidateAsync(It.IsAny<TaskItemDto>(), CancellationToken.None))
            .ReturnsAsync(new ValidationResult());
        _mockRepo.Setup(r => r.GetTaskByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((TaskItem)null!);

        var command = new UpdateTaskCommand(It.IsAny<int>(), It.IsAny<TaskItemDto>());
        var handler =
            new UpdateTaskCommandHandler(_mockRepo.Object, _mockUpdateTaskValidator.Object);
        
        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.Success.Should().Be(false);
    }

    [Test]
    public async Task UpdateTaskCommandHandler_ReturnsNotFound_WhenRepoReturnsNull()
    {
        // arrange
        _mockUpdateTaskValidator.Setup(v => v.ValidateAsync(It.IsAny<TaskItemDto>(), CancellationToken.None))
            .ReturnsAsync(new ValidationResult());
        _mockRepo.Setup(r => r.GetTaskByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((TaskItem)null!);

        var command = new UpdateTaskCommand(It.IsAny<int>(), It.IsAny<TaskItemDto>());
        var handler =
            new UpdateTaskCommandHandler(_mockRepo.Object, _mockUpdateTaskValidator.Object);
        
        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.NotFound.Should().Be(true);
    }

    [Test]
    public async Task UpdateTaskCommandHandler_ReturnsSuccessTrue_WhenValidDto_AndRepoReturnsTaskItem()
    {
        // arrange
        _mockUpdateTaskValidator.Setup(v => v.ValidateAsync(It.IsAny<TaskItemDto>(), CancellationToken.None))
            .ReturnsAsync(new ValidationResult());
        _mockRepo.Setup(r => r.GetTaskByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new TaskItem());
        _mockRepo.Setup(r => r.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        var command = new UpdateTaskCommand(It.IsAny<int>(), new TaskItemDto());
        var handler =
            new UpdateTaskCommandHandler(_mockRepo.Object, _mockUpdateTaskValidator.Object);
        
        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.Success.Should().Be(true);
    }

    [Test]
    public async Task DeleteTaskCommandHandler_ReturnsFalse_WhenRepoReturnsNull()
    {
        // arrange
        _mockRepo.Setup(r => r.GetTaskByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((TaskItem)null!);

        var command = new DeleteTaskCommand(It.IsAny<int>());
        var handler = new DeleteTaskCommandHandler(_mockRepo.Object);

        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.Should().Be(false);
    }
    
    [Test]
    public async Task DeleteTaskCommandHandler_ReturnsTrue_WhenRepoReturnsTaskItem()
    {
        // arrange
        _mockRepo.Setup(r => r.GetTaskByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new TaskItem());
        _mockRepo.Setup(r => r.DeleteTaskAsync(It.IsAny<TaskItem>())).Returns(Task.CompletedTask);

        var command = new DeleteTaskCommand(It.IsAny<int>());
        var handler = new DeleteTaskCommandHandler(_mockRepo.Object);

        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.Should().Be(true);
    }
}