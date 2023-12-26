using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : Controller
    {
        
        private readonly DB_SEP490Context _db;
        private readonly ICourseRepository _course;
      

        //public CourseController(ICourseRepository course, DB_SEP490Context db)
        //{
          
        //    _db = db;
        //    _course = course;
          
        //}

        public CourseController(ICourseRepository course)
        {

          
            _course = course;

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

        [HttpGet("Getqr")]
        public IActionResult Getqr()
        {
            // Lấy thông tin về khóa học dựa trên courseId

          

            // Đường dẫn đầy đủ tới tệp hình ảnh
            var imagePath = Path.Combine(@"C:\Users\ngoba\OneDrive\Máy tính\SEP_BackEnd\SEP_BackEnd\SEP_BackEndCodeApi\Photos\Qr.jpg");

            // Kiểm tra xem tệp hình ảnh có tồn tại không
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound(); // Trả về lỗi 404 nếu tệp hình ảnh không tồn tại
            }

            // Trả về hình ảnh dưới dạng tệp stream
            var imageStream = System.IO.File.OpenRead(imagePath);
            return File(imageStream, "image/jpeg"); // Thay đổi kiểu MIME theo định dạng của hình ảnh
        }


        [HttpGet]
        public IActionResult GetAllCourse()
        {
            try
            {
                var listCourse = _course.GetCourseList();
                return Ok(listCourse);
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpGet]
        public IActionResult GetCourseById(int courseId) {
            try
            {
                Course Course = _course.getCourseById(courseId);
                return Ok(Course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCourseByName(string courseName)
        {
            try
            {
                var Course = _course.getCourseByName(courseName);
                return Ok(Course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetClassInCourse(int courseId)
        {
            try
            {
                var Course = _course.getClassInCourse(courseId);
                return Ok(Course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddNewCouse(Course course)
        {
            try
            {
                _course.AddNewCourse(course);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateCourse(Course course)
        {
            try
            {
                _course.Update(course);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult DeleteCourse(Course course)
        {
            try
            {
                _course.DeleteCourse(course);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //hien thi toan bo danh sach cac khoa hoc
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            try
            {
                var listCourse = _db.Courses.ToList();
                return Ok(listCourse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //top khoa hoc moi
        [HttpGet]
        public IActionResult GetTopCourseByDate()
        {
            try
            {
                var result = _db.Courses.OrderByDescending(ob => ob.CreateDate).Take(5).ToList();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
