// FunDooNotes_App.BLL/Services/UserService.cs
using Microsoft.AspNetCore.Identity;
using FunDooNotes_App.BLL.Interfaces;
using FunDooNotes_App.DAL.Entities;
using FunDooNotes_App.DAL.Repositories;
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
            // Check if a user with the same email exists
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser != null)
                throw new Exception("User with this email already exists");

            // Hash the password (so if you pass "zaid", the stored value will be hashed)
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success ? user : null;
        }
    }
}
