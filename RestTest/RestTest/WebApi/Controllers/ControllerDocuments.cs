using Microsoft.AspNetCore.Mvc;
using RestTest.Db.Models;
using RestTest.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestTest.WebApi.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class ControllerDocuments
        : ControllerBase
    {
        // PUBLIC

        // constructor

        public ControllerDocuments(IDbService dbService, IStorageService storageService)
        {
            mDbService = dbService;
            mStorageService = storageService;
        }

        // methods

        [HttpGet]
        public async Task<ActionResult<List<Document>>> GetAll()
        {
            await mDbService.AddFile();
            return await mDbService.GetFiles();

            //await mStorageService.AddFile();

            //return new List<Document>();
        }

        // PRIVATE

        // members

        private readonly IDbService mDbService;
        private readonly IStorageService mStorageService;
    }
}