using LibraryManagement.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Books
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
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

                _context.Remove(book);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}
