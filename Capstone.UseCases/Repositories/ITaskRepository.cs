using Capstone.Domain.Entities;

namespace Capstone.UseCases.Repositories;

public interface ITaskRepository
{
    public Task<List<TaskItem>?> GetAllTasksAsync();
    public Task<TaskItem?> GetTaskByIdAsync();
    public Task<List<TaskItem>?> GetCompleteTasksAsync();
    public Task<List<TaskItem>?> GetIncompleteTasksAsync();
    public Task<List<TaskItem>?> GetOverdueTasksAsync();
    public Task AddTaskAsync();
    public Task DeleteTaskAsync();
}