using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMadeSimple.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningMadeSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        internal DB Db { get; set; }
        public SemesterController(DB db) { Db = db; }

        // GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetAllSemesterAsync()
        {
            await Db.Connection.OpenAsync();
            var query = new Semester(Db);
            var result = await query.GetSemestersAsync();
            return new OkObjectResult(result);
        }

        // GET: api/student
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentSemesterAsync()
        {
            await Db.Connection.OpenAsync();
            var query = new Semester(Db);
            var result = await query.GetCurrentSemesterAsync();
            return new OkObjectResult(result);
        }

        // GET: api/student/time
        [HttpGet("{time}")]
        public async Task<IActionResult> GetFutureSemesterAsync(string time)
        {
            await Db.Connection.OpenAsync();
            var query = new Semester(Db);
            var result = await query.GetFutureSemestersAsync(time);
            return new OkObjectResult(result);
        }
    }
}
