using System.Collections.Generic;
using System.Threading.Tasks;
using RestTest.Db.Models;

namespace RestTest.Interfaces
{
    public interface IDbService
    {
        bool IsConnected();
        Task<bool> AddFile();
        Task<List<Document>> GetFiles();
    }
}
