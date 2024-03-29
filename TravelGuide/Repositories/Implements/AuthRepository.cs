using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Text;
using TravelGuide.Entity;
using TravelGuide.Repositories.Interfaces;
using System.Security.Cryptography;
using Microsoft.AspNetCore.DataProtection;

namespace TravelGuide.Repositories.Implements
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
            var isUserExists = await IsUserExists(user.Email);
            if (isUserExists) return "User already exists";

            user.Password = CreatePasswordHash(user.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return "User created";
        }

        public async Task<string> SignIn(string email, string password)
        {
            if (await VerifyUser(email, password))
            {
                var user = await GetUser(email);
                var token = CreateToken(user);
                return token;
            }
            return "Data isn't correct";
        }

        private string CreatePasswordHash(string password)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes("mypsswd");
            byte[] messageBytes = encoding.GetBytes(password);
            using (var hmacsha512 = new HMACSHA512(keyByte))
            {
                byte[] hashmessage = hmacsha512.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        private async Task<User?> GetUser(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
        }
        
        private async Task<bool> IsUserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

            
        private async Task<bool> VerifyUser(string email, string password)
        {
            var user = await GetUser(email);
            if (user == null)
                return false;

            var passwordHash = CreatePasswordHash(password);

            if (user.Password == passwordHash)
            {
                return true;
            }

            return false;
        }

        private string CreateToken(User user)
        {
            const int ExpirationMinutes = 365; 

            /*var role = await _context.Roles.FindAsync(person.RoleId);*/
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var jwt = new JwtSecurityToken(
                    issuer: _configuration.GetSection("Jwt:Issuer").ToString(),
                    audience: _configuration.GetSection("Jwt:Audience").ToString(),
            claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(ExpirationMinutes), 
                    signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").ToString()));
    }
}
