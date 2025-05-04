using LibraryManagement.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Books.Queries;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("most-borrowed")]
        public async Task<IActionResult> GetMostBorrowed([FromQuery] int count = 10)
        {
            // This assumes a GetMostBorrowedBooksQuery exists in Application layer
            var result = await _mediator.Send(new GetMostBorrowedBooksQuery { Count = count });
            return Ok(result);
        }

        [HttpGet("least-borrowed")]
        public async Task<IActionResult> GetLeastBorrowed([FromQuery] int count = 10)
        {
            // This assumes a GetLeastBorrowedBooksQuery exists in Application layer
            var result = await _mediator.Send(new GetLeastBorrowedBooksQuery { Count = count });
            return Ok(result);
        }
    }
} 