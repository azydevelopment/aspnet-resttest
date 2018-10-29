using Microsoft.AspNetCore.Mvc;
using RestTest.DbService.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestTest.DbService.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class ControllerDocuments : ControllerBase
    {
        // PUBLIC

        public ControllerDocuments(DbContextDocuments dbContext)
        {
            mDbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Document>> GetAll()
        {
			string documentName = mDbContext.mDocuments.Count().ToString();

			Document document = new Document
			{
				mName = documentName
			};

			mDbContext.mDocuments.Add(document);
			mDbContext.SaveChanges();

			return mDbContext.mDocuments.ToList();
        }

        // PRIVATE

        private readonly DbContextDocuments mDbContext;
    }
}