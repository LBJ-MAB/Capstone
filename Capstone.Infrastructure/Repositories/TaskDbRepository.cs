using Capstone.Domain.Entities;
using Capstone.Infrastructure.Persistence;
using Capstone.UseCases.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Infrastructure.Repositories;

public class TaskDbRepository : ITaskRepository
{
    private readonly TaskDb _context;
    
    public TaskDbRepository(TaskDb context)
    {
        _context = context;
    }
    
    public async Task<List<TaskItem>?> GetAllTasksAsync()
    {
        var tasks = await _context.Tasks.ToListAsync();
        return tasks;
    }
    public async Task<TaskItem?> GetTaskByIdAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        return task;
    }
    public async Task<List<TaskItem>?> GetCompleteTasksAsync()
    {
        var completeTasks = await _context.Tasks.Where(t => t.IsComplete).ToListAsync();
        return completeTasks;
    }
    public async Task<List<TaskItem>?> GetIncompleteTasksAsync()
    {
        var incompleteTasks = await _context.Tasks.Where(t => !t.IsComplete).ToListAsync();
        return incompleteTasks;
    }
    public async Task<List<TaskItem>?> GetOverdueTasksAsync()
    {
        var overdueTasks = await _context.Tasks
            .Where(t => !t.IsComplete && t.DueDate < DateTime.UtcNow)
            .ToListAsync();
        return overdueTasks;
    }
    public async Task AddTaskAsync(TaskItem taskItem)
    {
        await _context.Tasks.AddAsync(taskItem);
        
    }
    public async Task DeleteTaskAsync(TaskItem taskItem)
    {
        _context.Tasks.Remove(taskItem);
        await _context.SaveChangesAsync();
    }
}