using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository _user;
        public UserController(IUserRepository user, IConfiguration config, DB_SEP490Context db)
        {
            _config = config;
            _db = db;
            _user = user;
        }

        [HttpGet("GetUserById/{UserID}")]
        public IActionResult GetTeacherById(int UserID)
        {
            var listClass = _db.Users.Where(x => x.UserId == UserID && x.RoleId ==1).ToList();
            if (listClass == null)
            {
                return NotFound();
            }
            return Ok(listClass);
        }
    }
}
