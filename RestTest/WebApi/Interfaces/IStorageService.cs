using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestTest.Interfaces
{
    public abstract class IStorageService
    {
        public abstract bool IsConnected();
        public abstract Task<bool> AddFile();
    }
}
