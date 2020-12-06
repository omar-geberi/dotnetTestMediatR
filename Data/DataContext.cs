using dotnet_book.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_book.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        
    }
}