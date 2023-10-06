using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository user;
        public UserController(IUserRepository _user, IConfiguration config, DB_SEP490Context db)
        {
            _config = config;
            _db = db;
            user = _user;
        }

        [HttpGet("GetUserById/{UserID}")]
        public IActionResult GetTeacherById(int UserID)
        {
            var listClass = _db.Users.Where(x => x.UserId == UserID && x.RoleId == 1).ToList();
            if (listClass == null)
            {
                return NotFound();
            }
            return Ok(listClass);
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var lstUser = user.GetUserList();
            return Ok(lstUser);
        }

        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserId == id);
            if (user != null)
            {
                foreach (var item in _db.Roles.ToList())
                {
                    if (item.RoleId == user.RoleId)
                    {
                        user.Role = item;
                    }
                }
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> GetUserByEmail(string email, string fullname)
        {
            if (email != null)
            {
                var use = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
                if (use == null)
                {
                    User a = new User
                    {
                        Email = email,
                        FullName = fullname,
                        RoleId = 2
                    };
                    _db.Users.Add(a);
                    await _db.SaveChangesAsync();
                    var id = await _db.Users.OrderBy(x => x.UserId).LastOrDefaultAsync();
                    return new JsonResult(id.UserId);

                }
                return new JsonResult(use.UserId);
            }
            return new JsonResult("");
        }

        [HttpPost]
        public IActionResult InsertUser(User use)
        {
            var a = user.GetUserByEmail(use.Email);
            if (a != null)
            {
                return NotFound();
            }
            user.AddNew(use);

            return Ok("Inserted Successfull!!!");
        }

        [HttpPut]
        public IActionResult UpdateUser(User u)
        {
            try
            {
                user.Update(u);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
