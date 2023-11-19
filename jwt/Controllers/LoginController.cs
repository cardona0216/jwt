﻿using jwt.Constants;
using jwt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _config;

        //creamos el constructor para la inyeccion de dependencias

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        { 
            var currentUser = GetCurrentUser();
            return Ok($"Hola {currentUser.FirstName}, tu eres {currentUser.Rol}");
        }

        [HttpGet]

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {

                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault( o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAdress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Rol =  userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,



                };
            }
            return null;
        }

        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                //crear el token
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("Usuario no encontrado");
        }


        private UserModel Authenticate(LoginUser userLogin)
        {
            var currentUser = UserContants.Users.FirstOrDefault(user => user.Username.ToLower() == userLogin.UserName.ToLower()
                    && user.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        private string Generate(UserModel user)
        {
            var securutyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));// con esta linea accedemos a la key
            var credentials = new SigningCredentials(securutyKey, SecurityAlgorithms.HmacSha256);

            //crear las reclamaciones(claims)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAdress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
                
            };


            //crear el token

            var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials:credentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }


    }

}
