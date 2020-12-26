using LibraryManagement.Core.Commands;
using LibraryManagement.Core.Common.Exceptions;
using LibraryManagement.Core.Common.Extensions;
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
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly DataContext _context;
        public UpdateBookCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
                throw new NotFoundException("Book", request.Id);
            book.CopyPropertiesFrom(request);
            var success = await _context.SaveChangesAsync() > 0;
            if (success) return book;
            throw new Exception("Problem saving changes");
        }

    }
}
