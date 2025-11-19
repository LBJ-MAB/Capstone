using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.UseCases.Repositories;
using MediatR;

namespace Capstone.UseCases.Queries.GetAllTasks;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItemDto>?>
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;
    // logger
    
    public GetAllTasksQueryHandler(ITaskRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<TaskItemDto>?> Handle(GetAllTasksQuery query, CancellationToken cancellationToken)
    {
        var allTasks = await _repo.GetAllTasksAsync();
        if (allTasks is null || !allTasks.Any())
        {
            return null;
        }
        
        var allTasksDtos = _mapper.Map<List<TaskItemDto>>(allTasks);
        
        // order by is complete -> due date -> priority
        return allTasksDtos.OrderBy(t => t.IsComplete).
            ThenBy(t => t.DueDate)
            .ToList();
    }
}