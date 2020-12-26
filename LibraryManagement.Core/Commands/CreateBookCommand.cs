using LibraryManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Core.Commands
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
    }
}
