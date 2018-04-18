﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ackbar.Models;
using Ackbar.Services;

namespace Ackbar.Controllers
{
    public class UserController : Controller
    {
        private readonly GameGuideContext _context;
        private readonly ILoginService _login;

        public UserController(GameGuideContext context, ILoginService login)
        {
            _context = context;
            _login = login;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { Email = "Alex", Password = "Alvim" });
                _context.SaveChanges();
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _login.Authenticate(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenString = _login.GenerateJwt(user);
            return Ok(new TokenResponse { Token = tokenString });
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            var user = _login.Signup(request.Email, request.Password);
            if (user == null) return BadRequest();
            var tokenString = _login.GenerateJwt(user);
            return Ok(new TokenResponse { Token = tokenString });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }
}