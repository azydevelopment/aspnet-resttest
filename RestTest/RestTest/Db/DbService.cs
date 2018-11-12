using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestTest.Db.Models;
using RestTest.Interfaces;

namespace RestTest.Db
{
    public class DbService
        : IDbService
    {
        // PUBLIC

        // types

        public class CONFIG
        {
            public string ConnectionString { get; set; } = "";
        }

        // constructor

        public DbService(CONFIG config)
        {
            DbContextOptions<DbContextDocuments> options = new DbContextOptionsBuilder<DbContextDocuments>()
            .UseSqlServer(config.ConnectionString)
            .Options;

            mContextDocuments = new DbContextDocuments(options);
        }

        // methods

        public override bool IsConnected()
        {
            return mContextDocuments != null;
        }

        public override async Task<bool> AddFile()
        {
            string documentName = (await mContextDocuments.mDocuments.CountAsync()).ToString();

            Document document = new Document
            {
                mName = documentName,
                mUrl = documentName
            };

            mContextDocuments.mDocuments.Add(document);

            await mContextDocuments.SaveChangesAsync();

            return true;
        }

        public override Task<List<Document>> GetFiles()
        {
            return mContextDocuments.mDocuments.ToListAsync();
        }

        // PRIVATE

        private readonly DbContextDocuments mContextDocuments;
    }
}
