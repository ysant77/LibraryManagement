using LibraryManagement.Core.Commands;
using LibraryManagement.Domain;
using LibraryManagement.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Handlers.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly DataContext _context;
        public CreateBookCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Name = request.Name,
                Price = request.Price,
                Category = request.Category,
                Author = request.Author
            };

            _context.Books.Add(book);
            var success = await _context.SaveChangesAsync() > 0;
            if (success) return book;
            throw new Exception("Problem saving changes");
        }
    }
}
