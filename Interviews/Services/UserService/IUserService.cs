using Interviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Services.UserService
{
    public interface IUserService
    {
        public Task<ActionResult<string>> RegisterUser(UserDto request);
        public Task<ActionResult<string>> LoginUser(UserDto request);
    }
}