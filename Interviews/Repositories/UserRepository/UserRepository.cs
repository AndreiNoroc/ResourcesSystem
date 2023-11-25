using Interviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly MobylabAppContext _dbContext;

        public UserRepository()
        {
            _dbContext = new MobylabAppContext();
        }

        public async Task<ActionResult<string>> RegisterUserRepo(User request)
        {
            await _dbContext.Users.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return "Succesfully added";
        }

        public async Task<ActionResult<User>> LoginUserRepo(UserDto request)
        {
            IEnumerable<User> entries = _dbContext.Users.Where(user => user.Username == request.Username).ToList();
            User result = entries.First();
            return result;
        }
    }
}
