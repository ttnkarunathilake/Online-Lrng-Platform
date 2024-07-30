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
        public async Task<IActionResult> Post(Student product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Student productData)
        {
            //if (productData == null || productData.Id == 0)
            //    return BadRequest();

            var product = await _context.Students.FindAsync(productData.StudentId);
            if (product == null)
                return NotFound();
            product.FirstName = productData.FirstName;
            product.LastName = productData.LastName;
            product.Nic = productData.Nic;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.Students.FindAsync(id);
            if (product == null)
                return NotFound();
            _context.Students.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
