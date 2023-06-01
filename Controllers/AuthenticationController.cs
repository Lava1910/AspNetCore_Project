using Microsoft.AspNetCore.Mvc;
using AspNetCore_Project.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using AspNetCore_Project.Dtos;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;


namespace AspNetCore_Project.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly TransportXContext _context;
        private readonly IConfiguration _config;
        public AuthenticationController(TransportXContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpPost]
        [Route("/register")]
        public IActionResult Register(UserRegister user)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(user.UserPassword);
            var u = new Entities.Account { UserEmail = user.UserEmail, UserName = user.UserName, Role = user.Role, UserPassword = hashed };
            _context.Accounts.Add(u);
            _context.SaveChanges();
            return Ok(new UserData { UserEmail = user.UserEmail, UserName = user.UserName, Role = user.Role, Token = GenerateJWT(u) });
        }

        private String GenerateJWT(Account user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signatureKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.UserEmail),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signatureKey
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
