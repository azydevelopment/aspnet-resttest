using Microsoft.EntityFrameworkCore;

namespace RestTest.Db.Models
{
    public class DbContextDocuments
        : DbContext
    {
        public DbSet<Document> mDocuments { get; set; }

        public DbContextDocuments(DbContextOptions<DbContextDocuments> options)
            : base(options)
        {
        }

    }
}
