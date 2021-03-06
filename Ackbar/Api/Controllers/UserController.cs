﻿using System.Collections.ObjectModel;
using System.Linq;
using Ackbar.Api.Dto;
using Ackbar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ackbar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly GameGuideContext _context;
        private readonly IJwtUtils _jwt;

        public UserController(GameGuideContext context, IJwtUtils jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = Authenticate(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenString = _jwt.GenerateJwt(user.Id);
            return Ok(new UserDto { Token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("Signup")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            var user = UserSignup(request.Email, request.Password, request.Reports, request.Name);
            if (user == null) return BadRequest();
            var tokenString = _jwt.GenerateJwt(user.Id);
            return Ok(new UserDto { Token = tokenString });
        }

        private User UserSignup(string email, string password, string[] reports, string name)
        {
            if (_context.Users.Any(u => u.Email == email))
            {
                return null;
            }
            var user = new User
            {
                Email = email,
                Password = password,
                Player = new Player
                {
                    Likes = new Collection<Like>()
                }
            };
            if (reports != null)
            {
                user.Customer = new Customer
                {
                    Name = name,
                    Reports = reports.ToList().Select(url => new Report
                    {
                        ReportUrl = url
                    }).ToList(),
                    User = user
                };
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        private User Authenticate(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}