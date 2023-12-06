using Interviews.Models;
using Interviews.Services.AdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Controllers.AdminController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService _adminService)
        {
            this._adminService = _adminService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<string>>> GetAllUsers()
        {
            return await _adminService.GetAllUsersService();
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> InsertUser([FromBody] UserDTORegister user)
        {
            return await _adminService.InsertUserService(user);
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> DeleteUser(string username)
        {
            return await _adminService.DeleteUserService(username);
        }
    }
}
