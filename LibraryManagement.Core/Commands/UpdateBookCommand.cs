using LibraryManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Core.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
    }
}
