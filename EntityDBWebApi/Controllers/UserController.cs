using LMS.Data.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityDBWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LMSDBContext _context;
        public UserController(LMSDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        [HttpGet("id")]
        public User GetId(int id)
        {
            return _context.Users.Find(id);
        }
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        [HttpPut]
        public User Put([FromBody] User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
        [HttpDelete("id")]
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
