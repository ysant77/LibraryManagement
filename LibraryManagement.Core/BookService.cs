using LibraryManagement.Domain;
using LibraryManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Core
{
    public class BookService
    {
        private readonly DataContext _context;
        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
        public async Task<Book> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                throw new Exception("error");
            return book;
        }
        public async Task Add(Book book)
        {
            _context.Books.Add(book);
            var success = await _context.SaveChangesAsync() > 0;
            if (!success) throw new Exception("Unable to save changes");
        }

        public async Task Update(Book book)
        {
            var existingBook = _context.Books.FindAsync(book.Id);
            if (existingBook == null)
                throw new Exception("Book does not exists");
            _context.Books.Update(book);
            var success = await _context.SaveChangesAsync() > 0;
            if (!success)
                throw new Exception("Unable to save changes");

        }

        public async void Delete(int id)
        {
            var book = _context.Books.FindAsync(id);
            if(book == null)
                throw new Exception("Book does not exists");
            _context.Books.Remove(book.Result);
            var success = await _context.SaveChangesAsync() > 0;
            if (!success)
                throw new Exception("problem deleting from books");
        }
    }
}
