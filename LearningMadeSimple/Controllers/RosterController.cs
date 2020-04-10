using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningMadeSimple.Models;
using System;

namespace LearningMadeSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RosterController : Controller
    {
        internal DB Db { get; }
        public RosterController(DB db) { Db = db; }

        // GET: api/roster/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradesById(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Roster(Db);
            var result = await query.GetGradesById(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // GET: api/roster/class/5
        [HttpGet("class/{id}")]
        public async Task<IActionResult> GetGradesByClassId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Roster(Db);
            var result = await query.GetGradesByClassId(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // GET: api/roster/student/5
        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetGradesByStudentId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Roster(Db);
            var result = await query.GetGradesByStudentIdAsync(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // GET: api/roster/section/5
        [HttpGet("section/{id}")]
        public async Task<IActionResult> GetGradesBySectionId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Roster(Db);
            var result = await query.GetGradesBySectionId(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}