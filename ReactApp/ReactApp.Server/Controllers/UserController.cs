using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Models;
using ReactApp.Server.Services.UserService;

namespace ReactApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userService.GetByIdAsync(id);
        }


        [HttpPost]
        [Route("Add")]
        public async Task InsertAsync(User user)
        {
            await _userService.AddAsync(user);
        }

        [HttpPost]
        [Route("Update")]
        public async Task Update(User user)
        {
            await _userService.Update(user);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteUser(Guid id)
        {
            await _userService.Delete(id);
        }
    }
}
