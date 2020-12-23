using System;

namespace LibraryManagement.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
    }
}
