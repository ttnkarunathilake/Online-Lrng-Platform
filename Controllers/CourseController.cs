using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearningAPI.Models;

namespace OnlineLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly OnlineLearningDbContext _context;

        public CourseController(OnlineLearningDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> Get()
        {
            return await _context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //if (id < 1)
            //    return BadRequest();
            var product = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Course courseData)
        {
            //if (courseData == null || courseData.Id == 0)
            //    return BadRequest();

            var student = await _context.Courses.FindAsync(courseData.Id);
            if (student == null)
                return NotFound();
            student.Name = courseData.Name;
            student.Description = courseData.Description;
            student.Duration = courseData.Duration;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            //if (id < 1)
            //    return BadRequest();
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound();
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
