using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearningMadeSimple.Models;

namespace LearningMadeSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        internal LMS_db Db { get; }
        public StudentController(LMS_db db)
        {
            Db = db;
        }


        // GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new StudentQuery(Db);
            var result = await query.GetAllAsync();
            return new OkObjectResult(result);
        }

        // GET: api/student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new StudentQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT: api/student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Student body)
        {
            await Db.Connection.OpenAsync();
            var query = new StudentQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null) return new NotFoundResult();
            result.Name = body.Name;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new StudentQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null) return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }
    }
}