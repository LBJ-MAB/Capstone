using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using Capstone.UseCases.Queries.GetAllTasks;
using Capstone.UseCases.Queries.GetCompleteTasks;
using Capstone.UseCases.Queries.GetIncompleteTasks;
using Capstone.UseCases.Queries.GetOverdueTasks;
using Capstone.UseCases.Queries.GetPagedTasks;
using Capstone.UseCases.Queries.GetTaskById;
using Capstone.UseCases.Repositories;
using Capstone.UseCases.Validation.Abstractions;
using FluentAssertions;
using Moq;

namespace Capstone.Tests.UnitTests;

[TestFixture]
public class QueryUnitTests
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
    public async Task GetAllTasksQueryHandler_ReturnsNull_WhenRepoReturnsNull()
    {
        // arrange
        _mockRepo.Setup(r => r.GetAllTasksAsync())
            .ReturnsAsync((List<TaskItem>)null!);

        var query = new GetAllTasksQuery();
        var handler = new GetAllTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetAllTasksQueryHandler_ReturnsNull_WhenRepoReturnsEmptyList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetAllTasksAsync())
            .ReturnsAsync([]);

        var query = new GetAllTasksQuery();
        var handler = new GetAllTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetAllTasksQueryHandler_ReturnsTaskItemDtoList_WhenRepoReturnsTaskItemList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetAllTasksAsync())
            .ReturnsAsync([
                new TaskItem()
            ]);
        _mockMapper.Setup(m => m.Map<List<TaskItemDto>>(It.IsAny<List<TaskItem>>()))
            .Returns([
                new TaskItemDto()
            ]);

        var query = new GetAllTasksQuery();
        var handler = new GetAllTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeOfType<List<TaskItemDto>?>();
    }
    
    [Test]
    public async Task GetCompleteTasksQueryHandler_ReturnsNull_WhenRepoReturnsNull()
    {
        // arrange
        _mockRepo.Setup(r => r.GetCompleteTasksAsync())
            .ReturnsAsync((List<TaskItem>)null!);

        var query = new GetCompleteTasksQuery();
        var handler = new GetCompleteTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetCompleteTasksQueryHandler_ReturnsNull_WhenRepoReturnsEmptyList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetCompleteTasksAsync())
            .ReturnsAsync([]);

        var query = new GetCompleteTasksQuery();
        var handler = new GetCompleteTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetCompleteTasksQueryHandler_ReturnsTaskItemDtoList_WhenRepoReturnsTaskItemList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetCompleteTasksAsync())
            .ReturnsAsync([
                new TaskItem()
            ]);
        _mockMapper.Setup(m => m.Map<List<TaskItemDto>>(It.IsAny<List<TaskItem>>()))
            .Returns([
                new TaskItemDto()
            ]);

        var query = new GetCompleteTasksQuery();
        var handler = new GetCompleteTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeOfType<List<TaskItemDto>?>();
    }

    [Test]
    public async Task GetIncompleteTasksQueryHandler_ReturnsNull_WhenRepoReturnsNull()
    {
        // arrange
        _mockRepo.Setup(r => r.GetIncompleteTasksAsync())
            .ReturnsAsync((List<TaskItem>)null!);

        var query = new GetIncompleteTasksQuery();
        var handler = new GetIncompleteTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetIncompleteTasksQueryHandler_ReturnsNull_WhenRepoReturnsEmptyList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetIncompleteTasksAsync())
            .ReturnsAsync([]);

        var query = new GetIncompleteTasksQuery();
        var handler = new GetIncompleteTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetIncompleteTasksQueryHandler_ReturnsTaskItemDtoList_WhenRepoReturnsTaskItemList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetIncompleteTasksAsync())
            .ReturnsAsync([
                new TaskItem()
            ]);
        _mockMapper.Setup(m => m.Map<List<TaskItemDto>>(It.IsAny<List<TaskItem>>()))
            .Returns([
                new TaskItemDto()
            ]);

        var query = new GetIncompleteTasksQuery();
        var handler = new GetIncompleteTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeOfType<List<TaskItemDto>?>();
    }
    
    [Test]
    public async Task GetOverdueTasksQueryHandler_ReturnsNull_WhenRepoReturnsNull()
    {
        // arrange
        _mockRepo.Setup(r => r.GetOverdueTasksAsync())
            .ReturnsAsync((List<TaskItem>)null!);

        var query = new GetOverdueTasksQuery();
        var handler = new GetOverdueTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetOverdueTasksQueryHandler_ReturnsNull_WhenRepoReturnsEmptyList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetOverdueTasksAsync())
            .ReturnsAsync([]);

        var query = new GetOverdueTasksQuery();
        var handler = new GetOverdueTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetOverdueTasksQueryHandler_ReturnsTaskItemDtoList_WhenRepoReturnsTaskItemList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetOverdueTasksAsync())
            .ReturnsAsync([
                new TaskItem()
            ]);
        _mockMapper.Setup(m => m.Map<List<TaskItemDto>>(It.IsAny<List<TaskItem>>()))
            .Returns([
                new TaskItemDto()
            ]);

        var query = new GetOverdueTasksQuery();
        var handler = new GetOverdueTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeOfType<List<TaskItemDto>?>();
    }
    
    [Test]
    public async Task GetPagedTasksQueryHandler_ReturnsNull_WhenRepoReturnsNull()
    {
        // arrange
        _mockRepo.Setup(r => r.GetPagedTasksAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync((List<TaskItem>)null!);

        var query = new GetPagedTasksQuery(It.IsAny<int>(), It.IsAny<int>());
        var handler = new GetPagedTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetPagedTasksQueryHandler_ReturnsNull_WhenRepoReturnsEmptyList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetPagedTasksAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync([]);

        var query = new GetPagedTasksQuery(It.IsAny<int>(), It.IsAny<int>());
        var handler = new GetPagedTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetPagedTasksQueryHandler_ReturnsTaskItemDtoList_WhenRepoReturnsTaskItemList()
    {
        // arrange
        _mockRepo.Setup(r => r.GetPagedTasksAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync([
                new TaskItem()
            ]);
        _mockMapper.Setup(m => m.Map<List<TaskItemDto>>(It.IsAny<List<TaskItem>>()))
            .Returns([
                new TaskItemDto()
            ]);

        var query = new GetPagedTasksQuery(It.IsAny<int>(), It.IsAny<int>());
        var handler = new GetPagedTasksQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeOfType<List<TaskItemDto>?>();
    }
    
    [Test]
    public async Task GetTaskByIdQueryHandler_ReturnsNull_WhenRepoReturnsNull()
    {
        // arrange
        _mockRepo.Setup(r => r.GetTaskByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((TaskItem)null!);

        var query = new GetTaskByIdQuery(It.IsAny<int>());
        var handler = new GetTaskByIdQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }
    [Test]
    public async Task GetTaskByIdQueryHandler_ReturnsTaskItemDto_WhenRepoReturnsTaskItem()
    {
        // arrange
        _mockRepo.Setup(r => r.GetTaskByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(
                new TaskItem()
            );
        _mockMapper.Setup(m => m.Map<TaskItemDto>(It.IsAny<TaskItem>()))
            .Returns(
                new TaskItemDto()
            );

        var query = new GetTaskByIdQuery(It.IsAny<int>());
        var handler = new GetTaskByIdQueryHandler(_mockRepo.Object, _mockMapper.Object);

        // act
        var result = await handler.Handle(query, CancellationToken.None);

        // assert
        result.Should().BeOfType<TaskItemDto>();
    }
}