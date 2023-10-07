using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]")]
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
            var listClass = _db.Users.Where(x => x.UserId == UserID && x.RoleId ==1).ToList();
            if (listClass == null)
            {
                return NotFound();
            }
            return Ok(listClass);
        }


        [HttpGet("GetImage/{UserID}")]
        public IActionResult GetUserImage(int UserID)
        {
            // Lấy thông tin về khóa học dựa trên courseId
            var user = _db.Users.FirstOrDefault(c => c.UserId == UserID);

            if (user == null || string.IsNullOrEmpty(user.Image))
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy khóa học hoặc không có tên tệp hình ảnh
            }

            // Đường dẫn đầy đủ tới tệp hình ảnh
            var imagePath = Path.Combine(@"C:\Users\ngoba\OneDrive\Máy tính\SEP_BackEnd\SEP_BackEnd\SEP_BackEndCodeApi\Photos\", user.Image);

            // Kiểm tra xem tệp hình ảnh có tồn tại không
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound(); // Trả về lỗi 404 nếu tệp hình ảnh không tồn tại
            }

            // Trả về hình ảnh dưới dạng tệp stream
            var imageStream = System.IO.File.OpenRead(imagePath);
            return File(imageStream, "image/jpeg"); // Thay đổi kiểu MIME theo định dạng của hình ảnh
        }

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
