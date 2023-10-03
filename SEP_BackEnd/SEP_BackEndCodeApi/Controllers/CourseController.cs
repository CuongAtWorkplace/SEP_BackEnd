using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{
    public class CourseController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository _user;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CourseController(IUserRepository user, IConfiguration config, DB_SEP490Context db, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _db = db;
            _user = user;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetImage/{courseId}")]
        public IActionResult GetImage(int courseId)
        {
            // Lấy thông tin về khóa học dựa trên courseId
            var course = _db.Courses.FirstOrDefault(c => c.CourseId == courseId);

            if (course == null || string.IsNullOrEmpty(course.Image))
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy khóa học hoặc không có tên tệp hình ảnh
            }

            // Đường dẫn đầy đủ tới tệp hình ảnh
            var imagePath = Path.Combine(@"C:\Users\ngoba\OneDrive\Máy tính\SEP_BackEnd\SEP_BackEnd\SEP_BackEndCodeApi\Photos\", course.Image);

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
