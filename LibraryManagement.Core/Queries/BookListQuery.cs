using LibraryManagement.Domain;
using MediatR;
using System.Collections.Generic;


namespace LibraryManagement.Core.Queries
{
    public class BookListQuery : IRequest<IEnumerable<Book>>
    {
    }
}
