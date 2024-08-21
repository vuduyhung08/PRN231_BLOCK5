using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBfirst.Models;
using DBfirst.DataAccess;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Diagnostics;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private readonly Project_B5DBContext _context;

        public EvaluationsController(Project_B5DBContext context)
        {
            _context = context;
        }

        // GET: api/Evaluations
        [HttpGet]
        [EnableQuery]
        public IQueryable<EvaluationDTO> Get()
        {
            return _context.Evaluations
                           .Include(e => e.Student)
                           .Select(e => new EvaluationDTO
                           {
                               EvaluationId = e.EvaluationId,
                               Grade = e.Grade,
                               AdditionExplanation = e.AdditionExplanation,
                               StudentId = e.StudentId.HasValue ? e.StudentId.Value : 0, // Trả về StudentId
                               StudentName = e.Student != null ? e.Student.Name : null // Trả về StudentName
                           })
                           .AsQueryable();
        }



        public class EvaluationDTO
        {
            public int EvaluationId { get; set; }
            public int Grade { get; set; }
            public string AdditionExplanation { get; set; }
            public int StudentId { get; set; } // Thêm StudentId
            public string StudentName { get; set; } // Thêm StudentName
        }




        // GET: api/Evaluations/5
        [HttpGet("{id}")]
        [EnableQuery]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _context.Evaluations.Where(e => e.EvaluationId == id);
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(SingleResult.Create(result));
        }

        // POST: api/Evaluations
        [HttpPost]
        public IActionResult Post([FromBody] EvaluationPostDTO evaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new Evaluation
            {
                Grade = evaluation.Grade,
                AdditionExplanation = evaluation.AdditionExplanation,
                StudentId = evaluation.StudentId // Gán StudentId
            };

            _context.Evaluations.Add(result);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = result.EvaluationId }, result);
        }

        public class EvaluationPostDTO
        {
            public int Grade { get; set; }
            public string AdditionExplanation { get; set; }
            public int StudentId { get; set; }
        }



        // PUT: api/Evaluations/5
        [HttpPut("{id}")]
        public IActionResult PutById([FromRoute] int id, [FromBody] Evaluation evaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evaluation.EvaluationId)
            {
                return BadRequest();
            }

            _context.Entry(evaluation).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Evaluations.Any(e => e.EvaluationId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Evaluations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var evaluation = _context.Evaluations.Find(id);
            if (evaluation == null)
            {
                return NotFound();
            }

            _context.Evaluations.Remove(evaluation);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
