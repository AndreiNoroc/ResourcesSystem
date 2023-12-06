using Interviews.Models;
using Interviews.Repositories.ResourcesRepository;
using Interviews.Repositories.UserRepository;
using Interviews.Services.AdminService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Interviews.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AdminService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<ActionResult<bool>> DeleteUserService(string username)
        {
            return await _userRepository.DeleteUserByUsernameAsync(username);
        }

        public async Task<ActionResult<List<string>>> GetAllUsersService()
        {
            return await _userRepository.GetAllUserRepo();
        }

        public async Task<ActionResult<string>> InsertUserService(UserDTORegister request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User();

            if (request.Role.Equals("Admin") || request.Role.Equals("User"))
            {
                user.Username = request.Username;
                user.Role = request.Role;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                return await _userRepository.RegisterUserRepo(user);
            }
            else
            {
                return "Wrong role";
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
