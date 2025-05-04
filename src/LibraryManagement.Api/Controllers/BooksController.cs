using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Books.Commands;
using LibraryManagement.Application.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetBooksQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.Id) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteBookCommand { Id = id });
            return NoContent();
        }

        [HttpPost("borrow")]
        [Authorize]
        public async Task<IActionResult> Borrow([FromBody] BorrowBookCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("return")]
        [Authorize]
        public async Task<IActionResult> Return([FromBody] ReturnBookCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
} 