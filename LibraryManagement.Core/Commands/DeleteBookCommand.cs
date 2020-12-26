using LibraryManagement.Domain;
using MediatR;

namespace LibraryManagement.Core.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
