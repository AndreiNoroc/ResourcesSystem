using Interviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ActionResult<List<string>>> GetAllUserRepo()
        {
            List<User> rawUsers = _dbContext.Users.ToList();
            List<string> usernames = new List<string>();

            foreach (User user in rawUsers)
            {
                usernames.Add(user.Username);
            }

            return usernames;
        }

        public async Task<bool> DeleteUserByUsernameAsync(string username)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
   
            Console.WriteLine(username);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
