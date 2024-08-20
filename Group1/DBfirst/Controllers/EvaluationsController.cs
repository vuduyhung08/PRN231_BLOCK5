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
                               Student = new StudentDTO
                               {
                                   StudentId = e.Student.StudentId,
                                   Name = e.Student.Name
                               }
                           })
                           .AsQueryable();
        }


        public class StudentDTO
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
        }

        public class EvaluationDTO
        {
            public int EvaluationId { get; set; }
            public int Grade { get; set; }
            public string AdditionExplanation { get; set; }
            public StudentDTO Student { get; set; }
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
                EvaluationId = 0,
                Grade = evaluation.Grade,
                AdditionExplanation = evaluation.AdditionExplanation,
                StudentId = evaluation.StudentId
            };

            _context.Evaluations.Add(result);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = evaluation.EvaluationId }, evaluation);
        }
        public class EvaluationPostDTO
        {
            public int EvaluationId { get; set; }
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
