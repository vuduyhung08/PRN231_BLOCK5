using DBfirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly BL5_PRN231_ProjectContext _projectContext;

        public ClassController(BL5_PRN231_ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        [HttpPost]
        public IActionResult PostClass([FromForm] ClassDTO newClass)
        {
            var classEntity = new Class
            {
                ClassName = newClass.ClassName,
                TeacherId = newClass.TeacherId,
                SubjectId = newClass.SubjectId
            };

            _projectContext.Classes.Add(classEntity);
            _projectContext.SaveChanges();

            return Ok(classEntity);
        }
    }
}
