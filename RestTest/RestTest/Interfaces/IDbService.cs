using System.Collections.Generic;
using System.Threading.Tasks;
using RestTest.Db.Models;

namespace RestTest.Interfaces
{
    public abstract class IDbService
    {
        public abstract bool IsConnected();
        public abstract Task<bool> AddFile();
        public abstract Task<List<Document>> GetFiles();
    }
}
