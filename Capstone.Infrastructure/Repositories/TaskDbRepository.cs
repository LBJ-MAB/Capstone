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
    public async Task<TaskItem?> GetTaskByIdAsync() 
    {
        
    }
    public async Task<List<TaskItem>?> GetCompleteTasksAsync() 
    {
        
    }
    public async Task<List<TaskItem>?> GetIncompleteTasksAsync() 
    {
        
    }
    public async Task<List<TaskItem>?> GetOverdueTasksAsync() 
    {
        
    }
    public async Task AddTaskAsync() 
    {
        
    }
    public async Task DeleteTaskAsync() 
    {
        
    }
}