using BulkBook.Models;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkBook.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       public DbSet<Category> Categories { get; set; }
       public DbSet<CoverType> coverTypes { get; set; }
    }
}
