using Interviews.Models;
using Interviews.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserDTORegister request)
        {
            return await _userService.RegisterUser(request);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            return await _userService.LoginUser(request);
        }

    }
}