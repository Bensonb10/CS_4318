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
    public class AssignmentController : ControllerBase
    {
        internal DB Db { get; set; }
        public AssignmentController(DB db) { Db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAssignmentsAsync()
        {
            await Db.Connection.OpenAsync();
            var query = new Assignment(Db);
            var result = await query.GetAssignmentsAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("section/{id}")]
        public async Task<IActionResult> GetAssignmentsSectionId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Assignment(Db);
            var result = await query.GetAssignmentsSectionId(id);
            return new OkObjectResult(result);
        }

        [HttpGet("section/type/{section}/{type}")]
        public async Task<IActionResult> GetAssignmentsSectionTypeId(int section, int type)
        {
            await Db.Connection.OpenAsync();
            var query = new Assignment(Db);
            var result = await query.GetAssignmentsSectionTypeId(section, type);
            return new OkObjectResult(result);
        }
    }
}
