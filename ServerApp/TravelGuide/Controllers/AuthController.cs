using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelGuide.Db.Entity;
using TravelGuide.Core.Services.Interfaces;

namespace TravelGuide.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("/sign_up")]
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            return Ok(await _authService.SignUp(user));
        }

        [Route("/sign_in")]
        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            return Ok(await _authService.SignIn(email, password));
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

        /*[Route("/test_jwt")]
        [HttpGet]
        public async Task<IActionResult> TestJwt(string jwt)
        {
            return Ok(await _authService.VeritifyJwt(jwt));
        }*/
    }
}
