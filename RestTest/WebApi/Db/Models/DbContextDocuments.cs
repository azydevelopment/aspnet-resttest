using Microsoft.EntityFrameworkCore;
using RestTest.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace RestTest.Db.Models
{
    public class DbContextDocuments
        : DbContext
        , IDbService
    {
        // PUBLIC

        // types

        public class CONFIG
        {
            public string ConnectionString { get; set; } = "";
        }

        // members

        public DbSet<Document> mDocuments { get; set; }

        // constructor

        public DbContextDocuments(DbContextOptions<DbContextDocuments> options)
            : base(options)
        {
        }

        // methods

        public bool IsConnected()
        {
            DbConnection conn = Database.GetDbConnection();

            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddFile()
        {
            string documentName = (await mDocuments.CountAsync()).ToString();

            Document document = new Document
            {
                mName = documentName,
                mUrl = documentName
            };

            mDocuments.Add(document);

            await SaveChangesAsync();

            return true;
        }

        public Task<List<Document>> GetFiles()
        {
            return mDocuments.ToListAsync();
        }
    }
}
