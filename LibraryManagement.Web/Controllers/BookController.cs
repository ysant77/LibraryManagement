using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Core;
using LibraryManagement.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            return  Ok(await _bookService.GetBook(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _bookService.Add(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Book book, int id)
        {
            book.Id = id;
            await _bookService.Update(book);
            return Ok();
        }
    }
}

