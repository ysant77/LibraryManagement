using LibraryManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryManagement.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
