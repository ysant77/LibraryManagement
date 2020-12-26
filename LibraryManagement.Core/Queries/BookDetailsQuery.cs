using LibraryManagement.Domain;
using MediatR;

namespace LibraryManagement.Core.Queries
{
    public class BookDetailsQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
}
