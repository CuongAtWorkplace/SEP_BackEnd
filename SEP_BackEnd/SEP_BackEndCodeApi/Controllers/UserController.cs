﻿using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        public IActionResult GetAllUser()
        {
            var lstUser = user.GetUserList();
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

    }
}