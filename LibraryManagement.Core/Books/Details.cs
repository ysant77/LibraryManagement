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
    public class Details
    {
        public class Query : IRequest<Book>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Book>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Book> Handle(Query request, CancellationToken cancellationToken)
            {
                var book = await _context.Books.FindAsync(request.Id);
                return book;
            }
        }
    }
}
