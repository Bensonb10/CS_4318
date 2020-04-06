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
    public class DegreeController : ControllerBase
    {
        internal DB Db { get; }
        public DegreeController(DB db) { Db = db; }

        // GET: api/degree
        [HttpGet]
        public async Task<IActionResult> GetAllDegree()
        {
            await Db.Connection.OpenAsync();
            var query = new Degree(Db);
            var result = await query.GetAllDegreesAsync();
            return new OkObjectResult(result);
        }

        // GET: api/degree/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDegreeById(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Degree(Db);
            var result = await query.FindDegreeByIdAsync(id);
            return new OkObjectResult(result);
        }

        // GET: api/degree/id
        [HttpGet("department/{id}")]
        public async Task<IActionResult> GetDegreeByDepartmentId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Degree(Db);
            var result = await query.FindDegreeByDepartmentIdAsync(id);
            return new OkObjectResult(result);
        }
    }
}
