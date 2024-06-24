using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TravelGuide.Core.Repositories.Interfaces;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;
using TravelGuide.Models.Models;
using TravelGuide.Utilites;

namespace TravelGuide.Core.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<string> SignUp(User user)
        {
            var isUserExists = await _authRepository.IsUserExists(user.Email);
            if (isUserExists) 
            return "User already exists";

            user.Password = CreatePasswordHash(user.Password);

            return await _authRepository.SignUp(user);
        }

        public async Task<string> SignIn(UserSignInRequest userRequest)
        {

            if (await VerifyUser(userRequest.Email, userRequest.Password))
            {
                var user = await GetUser(userRequest.Email);
                var token = CreateToken(user);
                return token;
            }

            return "Data isn't correct";

            //return await _authRepository.SignIn(email, password);
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

        public async Task<User?> GetUser(string email)
        {
            return await _authRepository.GetUser(email);
        }

        public async Task<bool> VerifyUser(string email, string password)
        {
            var user = await _authRepository.GetUser(email);
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

        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(AuthOptions.KEY));

        public async Task<User> GetById(int id)
        {
            return await _authRepository.GetById(id);
        }
    }
}
