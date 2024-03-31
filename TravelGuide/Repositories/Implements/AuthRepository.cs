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
using Microsoft.Extensions.Configuration;

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
            byte[] keyByte = encoding.GetBytes(AuthOptions.KEY);
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
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
            claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(ExpirationMinutes), 
                    signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<string> VeritifyJwt(string jwt)
        {
            string signingKey = AuthOptions.KEY;
            string[] tokenParts = jwt.Split('.');
            string header = DecodeBase64(tokenParts[0]);
            string payload = DecodeBase64(tokenParts[1]);
            string signature = tokenParts[2];
            string expectedSignature = ComputeSignature(header + "." + payload, signingKey);
            return signature + "    +    " + expectedSignature;
        }

        private string DecodeBase64(string base64)
        {
            string padded = base64 + new string('=', (4 - base64.Length % 4) % 4);
            byte[] bytes = Convert.FromBase64String(padded);
            return Encoding.UTF8.GetString(bytes);
        }

        private string ComputeSignature(string input, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(AuthOptions.KEY));
    }
}
