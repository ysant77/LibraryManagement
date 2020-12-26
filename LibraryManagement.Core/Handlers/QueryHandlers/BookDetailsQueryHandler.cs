using LibraryManagement.Core.Common.Exceptions;
using LibraryManagement.Core.Queries;
using LibraryManagement.Domain;
using LibraryManagement.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Handlers.QueryHandlers
{
    public class BookDetailsQueryHandler : IRequestHandler<BookDetailsQuery, Book>
    {
        private readonly DataContext _context;
        public BookDetailsQueryHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Book> Handle(BookDetailsQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
                throw new NotFoundException("Book", request.Id);
            return book;
        }
    }
}
