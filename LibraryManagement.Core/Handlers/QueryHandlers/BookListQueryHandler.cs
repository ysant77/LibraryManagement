using LibraryManagement.Core.Queries;
using LibraryManagement.Domain;
using LibraryManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Handlers.QueryHandlers
{
    public class BookListQueryHandler : IRequestHandler<BookListQuery, IEnumerable<Book>>
    {
        private readonly DataContext _context;
        public BookListQueryHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> Handle(BookListQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
    }
}
