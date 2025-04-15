using AutoMapper;
using Ollyware.Flowlly.Core.API.Application.Features.Tasks.DeleteTask;
using Ollyware.Flowlly.Core.API.Application.Features.Tasks.EditTask;
using Ollyware.Flowlly.Core.API.Application.Features.Tasks.GetAllTasks;
using Ollyware.Flowlly.Core.API.Application.Features.Tasks.RetrieveTaskDetails;
using Ollyware.Flowlly.Core.API.Application.Features.Tasks.SaveTask;
using Ollyware.Flowlly.Core.API.Domain.Dtos;
using Ollyware.Flowlly.Core.API.Domain.Entities;
using Ollyware.Flowlly.Core.API.Domain.Requests.Tasks;

namespace Ollyware.Flowlly.Core.API.Application.MapperConfiguration;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<SaveTaskRequest, SaveTaskCommand>();
        CreateMap<EditTaskRequest, EditTaskCommand>();
        CreateMap<DeleteTaskRequest, DeleteTaskCommand>();
        CreateMap<GetAllTasksRequest, GetAllTasksCommand>();
        CreateMap<TaskEntity, TaskDto>();
    }
}
