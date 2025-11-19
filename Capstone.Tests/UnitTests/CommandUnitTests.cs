using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using Capstone.UseCases.Commands.AddTask;
using Capstone.UseCases.Repositories;
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
    private Mock<IValidator<TaskItemDto>> _mockAddTaskValidator;
    private Mock<IValidator<TaskItemDto>> _mockUpdateTaskValidator;
    private Mock<IMapper> _mockMapper;
    
    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<ITaskRepository>();
        _mockAddTaskValidator = new Mock<IValidator<TaskItemDto>>();
        _mockUpdateTaskValidator = new Mock<IValidator<TaskItemDto>>();
        _mockMapper = new Mock<IMapper>();
    }

    [Test]
    public async Task AddTaskCommandHandler_ReturnsSuccessFalse_WhenValidatorReturnsFalse()
    {
        // arrange
        _mockAddTaskValidator.Setup(v => v.ValidateAsync(It.IsAny<TaskItemDto>(), CancellationToken.None))
            .ReturnsAsync(new ValidationResult([new ValidationFailure("property", "error")]));
        
        var command = new AddTaskCommand(It.IsAny<TaskItemDto>());
        var handler = new AddTaskCommandHandler(_mockRepo.Object, [ _mockAddTaskValidator.Object, _mockUpdateTaskValidator.Object ], _mockMapper.Object);
        
        // act
        var result = await handler.Handle(command, CancellationToken.None);

        // assert
        result.Success.Should().Be(false);
    }
}