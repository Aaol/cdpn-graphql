using BooksApiDbLib.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApiDbLib
{
    public class BookContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Author> Books { get; set; }
        public DbSet<BookComment> BookComments { get; set; }
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        { }
        public BookContext() : this(new DbContextOptionsBuilder<BookContext>()
        .UseSqlServer(@"Server=localhost;Database=Book;Trusted_Connection=True;")
        .Options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
            .HasKey(author => author.Identifier)
            .HasName("PK_Author");
            modelBuilder.Entity<Book>()
            .HasKey(book => book.Identifier)
            .HasName("PK_Book"); ;
            modelBuilder.Entity<BookComment>()
            .HasKey(comment => comment.Identifier)
            .HasName("PK_BookComment"); ;
        }
    }
}