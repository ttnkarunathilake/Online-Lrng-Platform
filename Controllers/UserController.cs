using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearningAPI.Models;

namespace OnlineLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OnlineLearningDbContext _context;

        public UserController(OnlineLearningDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _context.Add(user);
            //_context.Add(student.User);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
