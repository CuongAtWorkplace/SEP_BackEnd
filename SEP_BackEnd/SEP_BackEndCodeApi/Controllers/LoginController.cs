using BussinessObject.Models;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SEP_BackEndCodeApi.Controllers
{
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
       public LoginController(IConfiguration config , DB_SEP490Context db) 
        { 
            _config = config;
            _db = db;
            
        }

        private User AuthenticateUser(string email, string password)
        {
            User _user = _db.Users.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));

            return _user;
        }

        [HttpPost]
        private IActionResult Login(LoginDTO login)
        {
            try
            {
                if (AuthenticateUser(login.Email, login.Password) != null)
                {
                    User user = _db.Users.Where(x => x.Email.Equals(login.Email)).SingleOrDefault();
                    Role role = _db.Roles.Where(u => u.RoleId == user.RoleId).SingleOrDefault();


                    // tạo danh sách các claim
                    var claims = new[]
                    {
                new Claim("userid", user.UserId.ToString()),
                new Claim("roleid", user.RoleId.ToString()),
                new Claim("fullname", user.FullName),
                new Claim("email", user.Email),
                new Claim(ClaimTypes.Role,role.RoleName),

                // thêm các claim khác tùy ý
            };
                    var token = GenerateToken(claims);

                    return Ok(new { token });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Unauthorized();
        }

        private string GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
