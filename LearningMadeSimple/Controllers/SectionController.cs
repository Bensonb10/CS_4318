using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningMadeSimple.Models;
using System;

namespace LearningMadeSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : Controller
    {
        internal DB Db { get; }
        public SectionController(DB db) { Db = db; }

        // GET: api/section
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new Section(Db);
            var result = query.GetSectionsAsync();
            return new OkObjectResult(result);
        }

        // GET: api/section/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectionById(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Section(Db);
            var result = await query.GetSectionsByIdAsync(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // GET: api/section/class/5
        [HttpGet("class/{id}")]
        public async Task<IActionResult> GetSectionByClassId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Section(Db);
            var result = await query.GetSectionsByClassIdAsync(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}