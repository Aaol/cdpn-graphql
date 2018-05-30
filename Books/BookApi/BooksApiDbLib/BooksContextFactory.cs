using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace BooksApiDbLib
{
    public class BookContextFactory : IDesignTimeDbContextFactory<BookContext>
    {
        public BookContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BookContext>();
            builder.UseSqlServer(@"Server=localhost;Database=Book;Trusted_Connection=True;");
            return new BookContext(builder.Options);
        }
    }
}