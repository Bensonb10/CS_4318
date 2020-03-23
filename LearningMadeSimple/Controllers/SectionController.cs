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
            var result = query.GetAllAsync();
            return new OkObjectResult(result);
        }

        // GET: api/student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Section(Db);
            var result = query.FindOneAsync(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST: api/section
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Section body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT: api/section/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Section body)
        {
            await Db.Connection.OpenAsync();
            var query = new Section(Db);
            var result = await query.FindOneAsync(id);
            if (result is null) return new NotFoundResult();

            result.Name = body.Name;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE: api/section/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Section(Db);
            var result = await query.FindOneAsync(id);
            if (result is null) return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }
    }
}