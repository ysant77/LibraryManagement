using LibraryManagement.Domain;
using LibraryManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Books
{
    public class List
    {
        public class Query : IRequest<List<Book>> { }

        public class Handler : IRequestHandler<Query, List<Book>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Book>> Handle(Query request, CancellationToken cancellationToken)
            {
                var books = await _context.Books.ToListAsync();
                return books;
            }
        }
    }
}
