using LibraryManagement.Domain;
using LibraryManagement.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Books
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public int Price { get; set; }
            public string Author { get; set; }
        }


        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var book = await _context.Books.FindAsync(request.Id);
                if (book == null)
                    throw new Exception("Could not find book");

                book.Name = request.Name ?? book.Name;
                book.Price = request.Price;
                book.Author = request.Author ?? book.Author;
                book.Category = request.Category ?? book.Category;

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}
