using System;
using System.Threading.Tasks;
using LibraryManagement.Core.Commands;
using LibraryManagement.Core.Common.Exceptions;
using LibraryManagement.Core.Queries;
using Microsoft.AspNetCore.Mvc;
using static LibraryManagement.Web.Contracts.ApiRoutes;

namespace LibraryManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ApiBaseController
    {

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return  Ok(await Mediator.Send(new BookListQuery()));
        }

        [HttpGet(BookRoutes.ByBookId)]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var book = await Mediator.Send(new BookDetailsQuery { Id = id });
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
                var book = await Mediator.Send(command);
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
                var result =  await Mediator.Send(command);
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
                var result = await Mediator.Send(new DeleteBookCommand { Id = id });
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

