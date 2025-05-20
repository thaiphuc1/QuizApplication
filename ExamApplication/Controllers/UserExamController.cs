using ExamApplication.Database;
using ExamApplication.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExamController : ControllerBase
    {
        //Database
        private readonly ApplicationDbContext dbContext;
        public UserExamController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        //create a user 
        [HttpPost]
        public IActionResult CreateUser(string fullname)
        {
            var existUser = dbContext.Users.FirstOrDefault(u => u.Fullname == fullname);
            if (existUser != null)
            {
                return BadRequest("User existed!");
            }
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Fullname = fullname
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return Ok("Create User successfully!");
        }
    }
}
