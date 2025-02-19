﻿using Agreement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Agreement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config) {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] LoginModel login)
        {
            if (login == null) {
                return BadRequest();
            }
            if (!Authenticate(login)) {
                return Unauthorized();
            }
            return Ok(new { Token = BuildToken() });
        }

        private string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JwtToken:Issuer"],
              _config["JwtToken:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool Authenticate(LoginModel login)
        {
            if (login.Username == _config["JwtToken:User"] && login.Password == _config["JwtToken:Pass"])
                return true;
            return false;
        }
    }
 }
