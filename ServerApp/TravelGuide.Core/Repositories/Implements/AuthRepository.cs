using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using TravelGuide.Db.Entity;
using TravelGuide.Db;
using TravelGuide.Core.Repositories.Interfaces;

namespace TravelGuide.Core.Repositories.Implements
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TravelGuideDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(TravelGuideDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> SignUp(User user)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return "User created";
        }


        public async Task<User?> GetUser(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
        }
        
        public async Task<bool> IsUserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
