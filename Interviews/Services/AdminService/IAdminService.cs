using Interviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Services.AdminService
{
    public interface IAdminService
    {
        public Task<ActionResult<List<string>>> GetAllUsersService();
        public Task<ActionResult<string>> InsertUserService(UserDTORegister user);
        public Task<ActionResult<bool>> DeleteUserService(string username);
    }
}
