using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Web.Contracts
{
    public static class ApiRoutes
    {
        public static class BookRoutes
        {
            public const string ByBookId = "{id}";
            public const string CreateBook = "create";
            public const string UpdateBook = "update/{id}";
            public const string DeleteBook = "delete/{id}";
        }
    }
}
