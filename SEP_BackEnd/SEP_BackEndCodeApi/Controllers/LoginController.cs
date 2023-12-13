using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SEP_BackEndCodeApi.Controllers
{
    public class MD5Helper
    {
        public static string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository _user;
       public LoginController(IUserRepository user,IConfiguration config , DB_SEP490Context db) 
        { 
            _config = config;
            _db = db;
            _user = user;
        }

        private User AuthenticateUser(string email, string password)
        {
            string hashedPassword = MD5Helper.GetMD5Hash(password);
            User _user = _db.Users.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(hashedPassword));

            return _user;
        }

        [HttpPost]
        public IActionResult AuthenticateLogin(LoginDTO login)
        {
            try
            {
                if (AuthenticateUser(login.Email, login.Password) != null)
                {
                    User user = _db.Users.Where(x => x.Email.Equals(login.Email)).SingleOrDefault();
                    Role role = _db.Roles.Where(u => u.RoleId == user.RoleId).SingleOrDefault();


                    
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


        [HttpPost]
        public IActionResult Resigter([FromBody] RegistrationModel registrationModel)
        {
            try
            {
                var checkUser = _user.GetUserByEmail(registrationModel.Email);
                if (checkUser != null)
                {
                    return BadRequest(new { Message = "Tên người dùng đã tồn tại." });
                }
                string encodedPassword = MD5Helper.GetMD5Hash(registrationModel.Password);
                User user = new User
                {

                    Email = registrationModel.Email,
                    FullName = registrationModel.FullName,
                    Password = encodedPassword,
                    Address = registrationModel.Address,
                    Description = registrationModel.Description,
                    Phone = registrationModel.Phone,
                    FeedbackId = 1,
                    Image = null,
                    IsBan = false,
                    RoleId = 1,
                    Token = null
                };
                _user.AddNew(user);

                // Trả về thông tin đăng ký thành công
                return Ok(new { Message = "Đăng ký thành công" });
            }
                catch (Exception ex)
            {
                return BadRequest(new { Message = "Đăng ký thất bại", Error = ex.Message });
            }
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

        public class RegistrationModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Description { get; set; }
            // Thêm các thông tin khác cần thiết cho đăng ký
        }
    }
}
