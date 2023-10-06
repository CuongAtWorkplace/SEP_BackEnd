using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("GetStudentById/{UserID}")]
        public IActionResult GetStudentById(int UserID)
        {
            var listClass = _db.Users.Where(x => x.UserId == UserID && x.RoleId == 2).ToList();
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
    }
}
