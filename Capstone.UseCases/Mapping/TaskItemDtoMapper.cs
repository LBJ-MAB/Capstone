using AutoMapper;
using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;

namespace Capstone.UseCases.Mapping;

public class TaskItemDtoMapper : Profile
{
    public TaskItemDtoMapper()
    {
        CreateMap<TaskItem, TaskItemDto>();
        CreateMap<TaskItemDto, TaskItem>();
    }
}