using Capstone.Domain.Entities;

namespace Capstone.UseCases.Repositories;

public interface ITaskRepository
{
    public Task<List<TaskItem>?> GetAllTasksAsync();
    public Task<TaskItem?> GetTaskByIdAsync(int Id);
    public Task<List<TaskItem>?> GetCompleteTasksAsync();
    public Task<List<TaskItem>?> GetIncompleteTasksAsync();
    public Task<List<TaskItem>?> GetOverdueTasksAsync();
    public Task AddTaskAsync(TaskItem taskItem);
    public Task DeleteTaskAsync(TaskItem taskItem);
    public Task SaveChangesAsync();
}