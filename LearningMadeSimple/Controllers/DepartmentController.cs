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
    public class DepartmentController : ControllerBase
    {
        internal DB Db { get; }
        public DepartmentController(DB db) { Db = db;  }

        // GET: api/department
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            await Db.Connection.OpenAsync();
            var query = new Department(Db);
            var result = await query.GetAllDepartmentsAsync();
            return new OkObjectResult(result);
        }

        // GET: api/department/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Department(Db);
            var result = await query.FindDepartmentByIdAsync(id);
            return new OkObjectResult(result);
        }
    }
}
