using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearningAPI.Models;

namespace OnlineLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly OnlineLearningDbContext _context;

        public StudentController(OnlineLearningDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //if (id < 1)
            //    return BadRequest();
            var product = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Student studentData)
        {
            //if (studentData == null || studentData.Id == 0)
            //    return BadRequest();

            var student = await _context.Students.FindAsync(studentData.StudentId);
            if (student == null)
                return NotFound();
            student.FirstName = studentData.FirstName;
            student.LastName = studentData.LastName;
            student.Nic = studentData.Nic;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            //if (id < 1)
            //    return BadRequest();
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
