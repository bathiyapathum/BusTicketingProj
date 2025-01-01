using Core.Interfaces;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> RegisterUserAsync(string fullName, string email, string passwordHash)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(email);

            if (existingUser != null)
                throw new InvalidOperationException("User with this email already exists.");

            var PasswordHash = HashPassword(passwordHash);

            var user = new Core.Entities.User(fullName, email, PasswordHash);
            await _userRepository.RegisterUserAsync(user);

            return "User registered successfully!";
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashBytes);
        }
    }
}
