using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ListStudentClassController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly ICourseRepository _course;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ListStudentClassController(ICourseRepository course, IConfiguration config, DB_SEP490Context db, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _db = db;
            _course = course;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("AddStudentsToClass")]
        public IActionResult AddStudentsToClass([FromBody] ListStudentClass model)
        {
            if (model == null)
            {
                return BadRequest("Dữ liệu JSON không hợp lệ.");
            }

            try
            {
                var classroom = _db.Classes.FirstOrDefault(c => c.ClassId == model.ClassId);

                if (classroom == null)
                {
                    return NotFound("Lớp học không tồn tại.");
                }

                bool userExists = _db.Users.Any(u => u.UserId == model.UserId);

                if (!userExists)
                {
                    return BadRequest("Một hoặc nhiều người dùng không tồn tại.");
                }
                var newListStudentClass = new ListStudentClass
                {
                    ClassId = model.ClassId,
                    CreateDate = DateTime.Now,
                    UserId = model.UserId,
                };

                _db.ListStudentClasses.Add(newListStudentClass);
                _db.SaveChanges();

                return Ok("Thêm sinh viên vào lớp học thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

        [HttpGet("CheckClassExists/{classId}/{userId}")]
        public IActionResult CheckClassExists(int classId, int userId)
        {
            try
            {
                // Kiểm tra xem lớp tồn tại với ClassId và UserId cụ thể
                var classroom = _db.ListStudentClasses.Where(c => c.ClassId == classId).ToList();
                if (classroom == null)
                {
                    return NotFound("Lớp học không tồn tại.");
                }

                // Kiểm tra xem người dùng tồn tại với UserId cụ thể
                bool userExists = classroom.Any(u => u.UserId == userId);
                if (!userExists)
                {
                    return NotFound("Người dùng không tồn tại.");
                }

                // Trả về thành công nếu cả hai điều kiện đều đúng
                return Ok("Lớp học và người dùng tồn tại.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }
        [HttpGet("AllUserClassRegister/{userId}")]
        public IActionResult AllUserClassRegister(int userId)
        {
            try
            {
                // Lấy danh sách classId từ biến classroom
                var classroom = _db.ListStudentClasses
                    .Where(c => c.UserId == userId)
                    .Select(c => c.ClassId)
                    .ToList();

                if (classroom == null)
                {
                    return NotFound("Lớp học không tồn tại.");
                }

                // Kiểm tra xem người dùng tồn tại với UserId cụ thể
                bool userExists = classroom.Any();
                if (!userExists)
                {
                    return NotFound("Người dùng không tồn tại.");
                }

                // Lấy tất cả các lớp học có classId nằm trong danh sách classroom
                var classes = _db.Classes
         .Where(c => classroom.Contains(c.ClassId))
         .Select(c => new
         {
             classId = c.ClassId,
             classname = c.ClassName,
             courseId = c.CourseId,
             courseName = c.Course.CourseName // Giả sử có mối quan hệ giữa Class và Course
         })
         .ToList();


                // Trả về danh sách các lớp học
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

    }
}

