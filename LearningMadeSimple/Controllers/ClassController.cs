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
    public class ClassController : ControllerBase
    {
        internal DB Db { get; }
        public ClassController(DB db) { Db = db; }

        // GET: api/class
        [HttpGet]
        public async Task<IActionResult> GetAllClassesAsync()
        {
            await Db.Connection.OpenAsync();
            var query = new Class(Db);
            var result = await query.GetClassesAsync();
            return new OkObjectResult(result);
        }

        // GET: api/class/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Class(Db);
            var result = await query.FindClassByIdAsync(id);
            return new OkObjectResult(result);
        }

        // GET: api/degree/id
        [HttpGet("department/{id}")]
        public async Task<IActionResult> GetClassByDepartmentId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Class(Db);
            var result = await query.FindClassByDepartmentIdAsync(id);
            return new OkObjectResult(result);
        }
    }
}
