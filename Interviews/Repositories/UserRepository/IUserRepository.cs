using Interviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public Task<ActionResult<string>> RegisterUserRepo(User request);
        public Task<ActionResult<User>> LoginUserRepo(UserDto request);
        public Task<ActionResult<List<string>>> GetAllUserRepo();
        public Task<bool> DeleteUserByUsernameAsync(string username);
    }
}
