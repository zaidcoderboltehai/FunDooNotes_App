// FunDooNotes_App.BLL/Services/UserService.cs
using Microsoft.AspNetCore.Identity;
using FunDooNotes_App.BLL.Interfaces;
using FunDooNotes_App.DAL.Entities;
using FunDooNotes_App.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace FunDooNotes_App.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            // Check if user already exists
            var existingUser = await _userRepository.GetByUsernameAsync(user.Username);
            if (existingUser != null)
                throw new Exception("User already exists");

            // Hash the password
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success ? user : null;
        }
    }
}
