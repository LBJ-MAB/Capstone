using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.UseCases.Repositories;
using MediatR;

namespace Capstone.UseCases.Queries.GetIncompleteTasks;

public class GetIncompleteTasksQueryHandler : IRequestHandler<GetIncompleteTasksQuery, List<TaskItemDto>?>
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;
    
    public GetIncompleteTasksQueryHandler(ITaskRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<TaskItemDto>?> Handle(GetIncompleteTasksQuery query, CancellationToken cancellationToken)
    {
        var incompleteTasks = await _repo.GetIncompleteTasksAsync();
        if (incompleteTasks is null || !incompleteTasks.Any())
        {
            return null;
        }

        var incompleteTasksDtos = _mapper.Map<List<TaskItemDto>>(incompleteTasks);
        
        return incompleteTasksDtos
            .OrderBy(t => t.DueDate)
            .ThenBy(t => t.Priority)
            .ToList();
    }
}