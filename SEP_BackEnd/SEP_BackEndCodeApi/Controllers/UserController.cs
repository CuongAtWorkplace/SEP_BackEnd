using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Numerics;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository user;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository _user, IConfiguration config, DB_SEP490Context db, ILogger<UserController> logger)
        {
            _config = config;
            _db = db;
            user = _user;
            _logger = logger;
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
        public IActionResult GetAllUser(int roleId)
        {
            var lstUser = user.GetUserList(roleId);
            return Ok(lstUser);
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

        [HttpPost("UploadImage/{UserID}")]
        public async Task<IActionResult> UploadImage(int UserID, IFormFile file)
        {
            try
            {
                // Kiểm tra xem có file nào được tải lên không
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                // Lấy thông tin về người dùng dựa trên UserID (sử dụng Entity Framework hoặc cách khác)
                var user = _db.Users.FirstOrDefault(c => c.UserId == UserID);

                if (user == null)
                {
                    return NotFound($"User with ID {UserID} not found.");
                }

                // Đường dẫn đầy đủ để lưu trữ tệp ảnh trên máy chủ
                var imagePath = Path.Combine(@"C:\Users\ngoba\OneDrive\Máy tính\SEP_BackEnd\SEP_BackEnd\SEP_BackEndCodeApi\Photos\", $"{UserID}_{DateTime.UtcNow.Ticks}.jpg");

                // Lưu tệp ảnh trên máy chủ
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Cập nhật tên tệp ảnh trong thông tin người dùng (hoặc cơ sở dữ liệu của bạn)
                user.Image = Path.GetFileName(imagePath);

                // Cập nhật thông tin người dùng trong cơ sở dữ liệu (hoặc cách khác)
                _db.SaveChanges();

                return Ok("Image uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPut("UpdateBalanceStudent/{balance}/{UserID}")]
        public IActionResult UpdateBalanceStudent(long balance , int UserID)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserId == UserID && x.RoleId == 2);

            if (user == null)
            {
                return NotFound();
            }
            user.Balance -= balance; // Trừ đi balance mới từ balance hiện tại

            try
            {
                _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi lưu vào cơ sở dữ liệu nếu cần
                return BadRequest("Lỗi khi cập nhật balance: " + ex.Message);
            }

            return Ok();
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

        [HttpPut("UpdateStudentById/{UserID}")]
        public ActionResult UpdateUserInfo(int UserID, [FromBody] User updatedUser)
        {
            var User = _db.Users.FirstOrDefault(x => x.UserId == UserID && x.RoleId == 2);

            if (User == null)
            {
                return BadRequest("Người dùng không tồn tại hoặc không có quyền cập nhật.");
            }

            if (updatedUser == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            // Cập nhật thông tin người dùng
            User.FullName = updatedUser.FullName;
            User.Email = updatedUser.Email;
            User.Phone = updatedUser.Phone;
            User.Address = updatedUser.Address;

            // Lưu thay đổi vào cơ sở dữ liệu
            _db.SaveChanges();

            return Ok();
        }

        /*

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
        */

        //danh sanh nguoi hoc trong lop do
        [HttpGet("{classId}")]
        public IActionResult GetListStudentInClass(int classId)
        {
            try
            {
                var listStudent = _db.ListStudentClasses.
                    Include(t => t.User).
                    Where(c => c.ClassId == classId).
                    Select(x => new StudentsInClassDTO()
                    {
                        ListStudentInClassId = x.ListStudentInClassId,
                        ClassId = x.ClassId,
                        UserId = x.UserId,
                        FullName = x.User.FullName,
                        Email = x.User.Email,
                        Phone = x.User.Phone,
                        Image = x.User.Image,
                        Address = x.User.Address,
                        CreateDate = x.CreateDate
                    }).ToList();
                if (listStudent == null)
                {
                    return NotFound();
                }
                return Ok(listStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //chi tiet nguoi hoc trong lop do
        [HttpGet("{userId}")]
        public IActionResult GetStudentDetailInClass(int userId)
        {
            try
            {
                var student = _db.Users.FirstOrDefault(x => x.UserId == userId);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //chi tiet nguoi dang nhap
        [HttpGet("{userId}")]
        public IActionResult GetUserProfile(int userId)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(x => x.UserId == userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //chinh sua thong tin nguoi dang nhap
        [HttpPut]
        public IActionResult EditProfile(EditUserDTO eUser)
        {
            try
            {
                User u = _db.Users.FirstOrDefault(n => n.UserId == eUser.UserId);
                if (u is null)
                {
                    return StatusCode(444, "User is not found");
                }
                else
                {
                    u.FullName = eUser.FullName;
                    u.Email = eUser.Email;
                    u.Phone = eUser.Phone;
                    u.Description = eUser.Description;
                    u.Address = eUser.Address;
                    _db.Users.Update(u);
                    int result = _db.SaveChanges();
                    return Ok(result);
                }
            }
            catch
            {
                return Conflict();
            }
        }

        [HttpPut("UpdateUserPassword/{Email}/{newPassword}")]
        public IActionResult UpdateUserPassword(string Email, string newPassword)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(u => u.Email == Email);

                if (user == null)
                {
                    return NotFound("User not found");
                }

               
                    // Cập nhật mật khẩu trong cơ sở dữ liệu
                    user.Password = newPassword;
                    _db.SaveChanges();

                    return Ok("Password updated successfully");
                
            }
            catch (Exception ex)
            {
                // Log lỗi nếu có
                return StatusCode(500, "Internal server error");
            }
        }

        //chinh sua thong tin nguoi dang nhap
        [HttpPut]
        public IActionResult ChangePassword(ChangePasswordDTO eUser)
        {
            try
            {
                User u = _db.Users.FirstOrDefault(n => n.UserId == eUser.UserId);
                if (u is null)
                {
                    return StatusCode(444, "User is not found");
                }
                else
                {
                    if(eUser.Password != eUser.NewPassword && eUser.NewPassword == eUser.RePassword)
                    {
                        u.Password = eUser.NewPassword;
                        _db.Users.Update(u);
                        int result = _db.SaveChanges();
                        return Ok(result);
                    }
                    else
                    {
                        return Conflict();
                    }
                }
            }
            catch
            {
                return Conflict();
            }
        }

        //chinh sua thong tin nguoi dang nhap
        [HttpPut]
        public IActionResult ChangeImage(ChangeImageDTO eUser)
        {
            try
            {
                User u = _db.Users.FirstOrDefault(n => n.UserId == eUser.UserId);
                if (u is null)
                {
                    return StatusCode(444, "User is not found");
                }
                else
                {
                    u.Image = eUser.Image;
                    _db.Users.Update(u);
                    int result = _db.SaveChanges();
                    return Ok(result);
                }
            }
            catch
            {
                return Conflict();
            }
        }
    }
}
