using System;
using System.Threading.Tasks;
using LibraryManagement.Core.Commands;
using LibraryManagement.Core.Common.Exceptions;
using LibraryManagement.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static LibraryManagement.Web.Contracts.ApiRoutes;

namespace LibraryManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return  Ok(await _mediator.Send(new BookListQuery()));
        }

        [HttpGet(BookRoutes.ByBookId)]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var book = await _mediator.Send(new BookDetailsQuery { Id = id });
                return Ok(book);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return StatusCode(500);
                }
            }

        }

        [HttpPost(BookRoutes.CreateBook)]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            try
            {
                var book = await _mediator.Send(command);
                return Created($"/books/created/{book.Id}", book);
            }
            catch(Exception ex)
            {
                if(ex is ValidationException exception)
                {
                    return BadRequest(exception.Errors);
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }

        [HttpPut(BookRoutes.UpdateBook)]
        public async Task<IActionResult> Edit([FromBody] UpdateBookCommand command, int id)
        {
            command.Id = id;
            try
            {
                var result =  await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ValidationException exception)
                {
                    return BadRequest(exception.Errors);
                }
                else if(ex is NotFoundException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500);
                }
            }

        }

        [HttpDelete(BookRoutes.DeleteBook)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBookCommand { Id = id });
                return Ok(result);
            }
            catch(Exception ex)
            {
                if(ex is NotFoundException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }
    }
}

