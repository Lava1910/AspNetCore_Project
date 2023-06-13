using AspNetCore_Project.Dtos;
using AspNetCore_Project.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


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

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLogin userLogin)
        {
            var user = _context.Accounts.Where(p => p.UserEmail.Equals(userLogin.UserEmail)).FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }
            bool verified = BCrypt.Net.BCrypt.Verify(userLogin.UserPassword, user.UserPassword);
            if (!verified)
            {
                return Unauthorized();
            }
            var Token = GenerateJWT(user);
            return Ok(new UserData { UserName = user.UserName, UserEmail = user.UserEmail, Token = GenerateJWT(user) });
        }

        [HttpGet]
        [Route("profile")]
        public IActionResult Profile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var Id = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var user = new UserData
                {
                    Id = Convert.ToInt32(Id),
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    UserEmail = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
                return Ok(user);
            }
            return Unauthorized(); //status 401
        }
    }
}
