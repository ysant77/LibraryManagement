using LibraryManagement.Core.Commands;
using LibraryManagement.Core.Common.Exceptions;
using LibraryManagement.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Handlers.CommandHandlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly DataContext _context;
        public DeleteBookCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
                throw new NotFoundException("Book", request.Id);
            _context.Remove(book);
            var success = await _context.SaveChangesAsync() > 0;
            if (success) return Unit.Value;
            throw new Exception("Problem saving changes");
        }
       
    }
}
