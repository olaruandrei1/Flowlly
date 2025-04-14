using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ollyware.Flowlly.Core.API.Application.Features.Tasks.DeleteTask;
using Ollyware.Flowlly.Core.API.Application.Features.Tasks.RetrieveTaskDetails;
using Ollyware.Flowlly.Core.API.Application.Features.Tasks.SaveTask;
using Ollyware.Flowlly.Core.API.Domain.Extensions;
using Ollyware.Flowlly.Core.API.Domain.Requests.Tasks;
using Ollyware.Flowlly.Core.API.Helpers;

namespace Ollyware.Flowlly.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(IMapper _mapper, IMediator _mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveTaskRequest request)
        => Ok(await _mediator.Send(_mapper.ToCommand(request)));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EditTaskRequest request)
        => Ok(await _mediator.Send(_mapper.ToCommand(request)));

        [HttpDelete("{TaskId}")]
        public async Task<IActionResult> Delete(Guid TaskId, [FromBody] DeleteTaskRequest request)
        => Ok(await _mediator.Send(_mapper.ToCommand(request)));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        => Ok(await _mediator.Send(new RetrieveTaskDetailsCommand(id)));
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTasksRequest request)
        => Ok(await _mediator.Send(_mapper.ToCommand(request)));
    }
}
