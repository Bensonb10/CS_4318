using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningMadeSimple.Models;
using System;

namespace LearningMadeSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        internal DB Db { get; }
        public StudentController(DB db)
        {
            Db = db;
        }


        // GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new Student(Db);
            var result = await query.GetAllAsync();
            return new OkObjectResult(result);
        }

        // GET: api/student/GetByDegreeId/5
        [HttpGet("getbydegreeid/{id}")]
        public async Task<IActionResult> GetByDegreeId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Student(Db);
            var result = await query.GetByDegreeId(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // GET: api/student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            HttpContext.Response.Cookies.Append("user_id", Convert.ToString(id));

            await Db.Connection.OpenAsync();
            var query = new Student(Db);
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

        // PUT: api/student
        [HttpPut]
        public async Task<IActionResult> PutOne([FromBody] Student body)
        {
            var userId = HttpContext.Request.Cookies["user_id"];
            var test_id = Int32.Parse(userId);

            await Db.Connection.OpenAsync();
            var query = new Student(Db);
            var result = await query.FindOneAsync(test_id);
            if (result is null) return new NotFoundResult();

            result.First_name = body.First_name;
            result.Last_name = body.Last_name;

            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Student(Db);
            var result = await query.FindOneAsync(id);
            if (result is null) return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }
    }
}