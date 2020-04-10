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
    public class SubmissionController : ControllerBase
    {
        internal DB Db { get; }
        public SubmissionController(DB db) { Db = db; }

        [HttpGet]
        public async Task<IActionResult> GetSubmissions()
        {
            await Db.Connection.OpenAsync();
            var query = new Submission(Db);
            var result = await query.GetSubmissionsAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubmissionsBySectionId(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Submission(Db);
            var result = await query.GetSubmissionBySectionId(id);
            return new OkObjectResult(result);
        }

        [HttpGet("student/{section}/{student}")]
        public async Task<IActionResult> GetSectionSubmissionsByStudentId(int section, int student)
        {
            await Db.Connection.OpenAsync();
            var query = new Submission(Db);
            var result = await query.GetSectionSubmissionByStudentId(section, student);
            return new OkObjectResult(result);
        }

        [HttpGet("type/{section}/{type}")]
        public async Task<IActionResult> GetSectionSubmissionsByTypeId(int section, int type)
        {
            await Db.Connection.OpenAsync();
            var query = new Submission(Db);
            var result = await query.GetSectionSubmissionByAssnTypeId(section, type);
            return new OkObjectResult(result);
        }

        [HttpGet("assn/{section}/{type}")]
        public async Task<IActionResult> GetSectionSubmissionsByAssnId(int section, int type)
        {
            await Db.Connection.OpenAsync();
            var query = new Submission(Db);
            var result = await query.GetSectionSubmissionByAssnId(section, type);
            return new OkObjectResult(result);
        }
    }
}
