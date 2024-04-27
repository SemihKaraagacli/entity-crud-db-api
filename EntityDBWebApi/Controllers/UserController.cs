using LMS.Data.entities;
using LMS.Data.Repositories.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityDBWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly LMSDBContext _context;
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            //_context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<User> GetId(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            return await _userRepository.InsertAsync(user);
        }
        [HttpPut]
        public async Task<User> Put([FromBody] User user)
        {
            return await _userRepository.UpdateAsync(user);
        }
        [HttpDelete("{id}")]
        public async Task<User> Delete(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}
