using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Tags.Commands;
using LibraryManagement.Application.Features.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetTagsQuery());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateTagCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id }, null);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTagCommand { Id = id });
            return NoContent();
        }
    }
} 