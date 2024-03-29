using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelGuide.Entity;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [Route("/sign_up")]
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            return Ok(await _authRepository.SignUp(user));
        }

        [Route("/sign_in")]
        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            return Ok(await _authRepository.SignIn(email, password));
        }

        [Route("/test_anonimous")]
        [HttpGet]
        public async Task<IActionResult> TestAnon()
        {
            return Ok("good");
        }

        [Authorize]
        [Route("/test_authorize")]
        [HttpGet]
        public async Task<IActionResult> TestLogin()
        {
            return Ok("good");
        }
    }
}
