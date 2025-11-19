using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.UseCases.Repositories;
using MediatR;

namespace Capstone.UseCases.Queries.GetCompleteTasks;

public class GetCompleteTasksQueryHandler : IRequestHandler<GetCompleteTasksQuery, List<TaskItemDto>?>
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;
    // logger

    public GetCompleteTasksQueryHandler(ITaskRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<TaskItemDto>?> Handle(GetCompleteTasksQuery query, CancellationToken cancellationToken)
    {
        var completeTasks = await _repo.GetCompleteTasksAsync();
        if (completeTasks is null || !completeTasks.Any())
        {
            return null;
        }

        var completeTasksDtos = _mapper.Map<List<TaskItemDto>>(completeTasks);
        
        // order by DueDate descending
        return completeTasksDtos.OrderByDescending(t => t.DueDate).ToList();
    }
}