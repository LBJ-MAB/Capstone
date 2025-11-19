using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.UseCases.Repositories;
using MediatR;

namespace Capstone.UseCases.Queries.GetPagedTasks;

public class GetPagedTasksQueryHandler : IRequestHandler<GetPagedTasksQuery, List<TaskItemDto>?>
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;

    public GetPagedTasksQueryHandler(ITaskRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<TaskItemDto>?> Handle(GetPagedTasksQuery query, CancellationToken cancellationToken)
    {
        var pagedTasks = await _repo.GetPagedTasksAsync(pageNumber: query.PageNumber, tasksPerPage: query.TasksPerPage);
        if (pagedTasks is null || !pagedTasks.Any())
        {
            return null;
        }

        var pagedTasksDtos = _mapper.Map<List<TaskItemDto>>(pagedTasks);
        return pagedTasksDtos;
    }

}