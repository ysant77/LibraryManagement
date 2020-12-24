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
    public class Create
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
                var book = new Book
                {
                    Name = request.Name,
                    Price = request.Price,
                    Category = request.Category,
                    Author = request.Author
                };
                _context.Books.Add(book);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}
