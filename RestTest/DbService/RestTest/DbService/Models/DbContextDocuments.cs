using Microsoft.EntityFrameworkCore;

namespace RestTest.DbService.Models
{
    public class DbContextDocuments : DbContext
    {
        public DbSet<Document> mDocuments { get; set; }

        public DbContextDocuments(DbContextOptions<DbContextDocuments> options)
            : base(options)
        {
        }

    }
}
