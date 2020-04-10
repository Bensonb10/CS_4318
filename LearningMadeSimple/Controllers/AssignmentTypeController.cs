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
    public class AssignmentTypeController : ControllerBase
    {
        internal DB Db { get; }
        public AssignmentTypeController(DB db) { Db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAssignmentTypes()
        {
            await Db.Connection.OpenAsync();
            var query = new AssignmentType(Db);
            var result = await query.GetAssignmentTypesAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("section/{id}")]
        public async Task<IActionResult> GetAssignmentTypeSectionId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new AssignmentType(Db);
            var result = await query.GetAssignmentTypeSectionId(id);
            if (result is null) return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
