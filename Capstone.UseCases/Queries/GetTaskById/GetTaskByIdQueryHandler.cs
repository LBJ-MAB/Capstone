using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.UseCases.Repositories;
using MediatR;

namespace Capstone.UseCases.Queries.GetTaskById;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto?>
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;
    // logger

    public GetTaskByIdQueryHandler(ITaskRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<TaskItemDto?> Handle(GetTaskByIdQuery query, CancellationToken cancellationToken)
    {
        var taskItem = await _repo.GetTaskByIdAsync(query.Id);
        if (taskItem is null)
        {
            return null;
        }

        var taskItemDto = _mapper.Map<TaskItemDto>(taskItem);
        return taskItemDto;
    }
}