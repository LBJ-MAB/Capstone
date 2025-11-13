using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.UseCases.Repositories;
using MediatR;

namespace Capstone.UseCases.Queries.GetOverdueTasks;

public class GetOverdueTasksQueryHandler : IRequestHandler<GetOverdueTasksQuery, List<TaskItemDto>?>
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;
    // logger
    
    public GetOverdueTasksQueryHandler(ITaskRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<TaskItemDto>?> Handle(GetOverdueTasksQuery query, CancellationToken cancellationToken)
    {
        var overdueTasks = await _repo.GetOverdueTasksAsync();
        if (overdueTasks is null || !overdueTasks.Any())
        {
            return null;
        }

        var overdueTasksDtos = _mapper.Map<List<TaskItemDto>>(overdueTasks);
        return overdueTasksDtos;
    }
}


















