﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _config;
        //api/account/register
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
        }
        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            //do something to put this in the database
            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName

            };
            //create the user
            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                //sign the user in if it was successful
                if(user.Email == _config["District Manager"])
                {
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.DistrictManager);
                }

                await _signInManager.SignInAsync(user, false);
                return Ok();

            }
            return BadRequest("invalid registration");
        }


        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

            if (result.Succeeded)
            {
                //look the user up
                var user = await _userManager.FindByEmailAsync(login.Email);
                //make them a token
                var token = CreateToken(user);
                //make them a token based on their account

                //send that tokenn back to user
                //log the user in
                return Ok(new
                {
                    jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo

                });
            }
            return BadRequest("invalid attempt");
        }

        [HttpPost, Route("assign/role")]
        [Authorize(Roles = ApplicationRoles.DistrictManager)]
        public async Task AssignRoleToDistrictManager(AssignRoleDTO assignment)
        {
            var user = await _userManager.FindByEmailAsync(assignment.Email);

            await _userManager.AddToRoleAsync(user, assignment.Role);
        }

        [HttpPost, Route("assign/role")]
        [Authorize(Roles = ApplicationRoles.PropertyManager)]
        public async Task AssignRoleToPropertyManager(AssignRoleDTO assignment)
        {
            var user = await _userManager.FindByEmailAsync(assignment.Email);

            await _userManager.AddToRoleAsync(user, assignment.Role);
        }

        [HttpPost, Route("assign/role")]
        [Authorize(Roles = ApplicationRoles.Agent)]
        public async Task AssignRoleToUser(AssignRoleDTO assignment)
        {
            var user = await _userManager.FindByEmailAsync(assignment.Email);

            await _userManager.AddToRoleAsync(user, assignment.Role);
        }

        private JwtSecurityToken CreateToken(ApplicationUser user)
        {
            //token requires information called claims
            //true statements or claims
            // Person/User is the principle
            //Principla can have many forms of identy
            //Identity contains many claims
            //claim is a single statement about the user

            var authClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("UserId", user.Id)
            };

            var token = AuthenticateToken(authClaims);

            return token;

        }

        private JwtSecurityToken AuthenticateToken(Claim[] claims)
        {
            var singningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(_config["JWTKey"]));

            var token = new JwtSecurityToken(
            issuer: _config["JWTIssuer"],
            expires: DateTime.UtcNow.AddHours(24),
            claims: claims,
            signingCredentials: new SigningCredentials(singningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
    }
}
