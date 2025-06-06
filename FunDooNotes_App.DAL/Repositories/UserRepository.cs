﻿// FunDooNotes_App.DAL/Repositories/UserRepository.cs
using Microsoft.EntityFrameworkCore;
using FunDooNotes_App.DAL.Entities;
using System.Threading.Tasks;

namespace FunDooNotes_App.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
