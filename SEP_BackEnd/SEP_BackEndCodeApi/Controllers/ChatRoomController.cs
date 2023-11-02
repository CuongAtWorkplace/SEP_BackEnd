using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ChatRoomController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository _user;
        private IHubContext<ChatHub> _hubContext; // Sử dụng IHubContext để gửi tin nhắn từ máy chủ tới máy khách


        public ChatRoomController(IUserRepository user, IConfiguration config, DB_SEP490Context db , IHubContext<ChatHub> hubContext)
        {
            _config = config;
            _db = db;
            _user = user;
            _hubContext = hubContext;

        }

        [HttpGet("{classId}")]
        public IActionResult GetAllClassMessages(int classId)
        {
            try
            {
                var messages = _db.ChatRooms
                    .Where(c => c.ClassId == classId)
                    .Join(_db.Messages,
                        chatRoom => chatRoom.ChatRoomId,
                        message => message.ChatRoomId,
                        (chatRoom, message) => new
                        {
                            message.MessageId,
                            chatRoom.ChatRoomId,
                            message.Content,
                            chatRoom.ChatRoomName,
                            message.CreateBy,
                            message.CreateDate,
                            message.Photo
                        })
                    .Join(_db.Users,
                        message => message.CreateBy,
                        user => user.UserId,
                        (message, user) => new
                        {
                            message.MessageId,
                            message.ChatRoomId,
                            message.Content,
                            message.ChatRoomName,
                            message.CreateBy,
                            message.CreateDate,
                            message.Photo,
                            user.FullName,
                            user.Role.RoleId
                        })
                    .ToList();
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }

        [HttpPost("{classId}/{userId}")]
        public IActionResult AddMessage([FromBody] MessageDto messageDTO, int classId, int userId)
        {
            try
            {
                // Sử dụng Include để nạp thông tin liên quan
                var chatRoom = _db.ChatRooms
                    .FirstOrDefault(c => c.ClassId == classId);

                if (messageDTO != null && chatRoom != null)
                {
                    // Tạo một đối tượng Message từ dữ liệu DTO và thông tin lớp và người dùng
                    var newMessage = new Message
                    {
                        ChatRoomId = chatRoom.ChatRoomId,
                        CreateBy = userId,
                        Content = messageDTO.Content,
                        CreateDate = DateTime.Now, // Ngày tạo là ngày hiện tại
                        Photo = messageDTO.Photo
                    };

                    // Thêm tin nhắn mới vào cơ sở dữ liệu và cập nhật danh sách tin nhắn của ChatRoom
                    // Sau khi lưu tin nhắn vào cơ sở dữ liệu
                    _db.Messages.Add(newMessage);
                    _db.SaveChanges();

                    // Tìm kiếm tin nhắn dựa trên CreateDate (ví dụ)
                    var addedMessage = _db.Messages.FirstOrDefault(m =>
                        m.CreateDate == newMessage.CreateDate &&
                        m.CreateBy == newMessage.CreateBy &&
                        m.Content == newMessage.Content);

                    var userFullName = _db.Users.FirstOrDefault(u => u.UserId == addedMessage.CreateBy);


                    var addedMessageDto = new MessageDto2
                    {
                        MessageId = addedMessage.MessageId,
                        ChatRoomId = chatRoom.ChatRoomId,
                        CreateBy = userId,
                        Content = messageDTO.Content,
                        CreateDate = DateTime.Now, // Ngày tạo là ngày hiện tại
                        Photo = messageDTO.Photo,
                        FullName = userFullName.FullName,
                        RoleId = userFullName.RoleId,
                    };

                    if (addedMessage != null)
                    {
                        _hubContext.Clients.All.SendAsync("ReceiveMessage", addedMessageDto);
                        return Ok(); // Trả về tin nhắn vừa được thêm vào cơ sở dữ liệu
                    }
                    else
                    {
                        return BadRequest("Không thể lấy thông tin tin nhắn sau khi thêm vào cơ sở dữ liệu.");
                    }
                }
                else
                {
                    return BadRequest("Dữ liệu tin nhắn không hợp lệ hoặc không tìm thấy lớp học.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi: {ex.Message}");
                
            }
        }

        [HttpDelete("{messageId}")]
        public IActionResult DeleteMessage(int messageId)
        {
            try
            {
                var message = _db.Messages.FirstOrDefault(m => m.MessageId == messageId);

                if (message == null)
                {
                    return NotFound("Message not found");
                }

                _db.Messages.Remove(message);
                _db.SaveChanges();

                return Ok("Message deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }



        [HttpGet("{MessId}")]
        public IActionResult GetImage(int MessId)
        {
            // Lấy thông tin về khóa học dựa trên courseId
            var course = _db.Messages.FirstOrDefault(c => c.MessageId == MessId);

            if (course == null || string.IsNullOrEmpty(course.Photo))
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy khóa học hoặc không có tên tệp hình ảnh
            }

            // Đường dẫn đầy đủ tới tệp hình ảnh
            var imagePath = Path.Combine(@"C:\Users\ngoba\OneDrive\Máy tính\SEP_BackEnd\SEP_BackEnd\SEP_BackEndCodeApi\Photos\", course.Photo);

            // Kiểm tra xem tệp hình ảnh có tồn tại không
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound(); // Trả về lỗi 404 nếu tệp hình ảnh không tồn tại
            }

            // Trả về hình ảnh dưới dạng tệp stream
            var imageStream = System.IO.File.OpenRead(imagePath);
            return File(imageStream, "image/jpeg"); // Thay đổi kiểu MIME theo định dạng của hình ảnh
        }

        public class MessageDto
        {
            public string Content { get; set; }
            public string Photo { get; set; }
        }

        public class MessageDto2
        {
            public int MessageId { get; set; }
            public int? ChatRoomId { get; set; }
            public int? CreateBy { get; set; }
            public string? Content { get; set; }
            public DateTime? CreateDate { get; set; }
            public string? Photo { get; set; }
            public string? FullName { get; set; }
            public int? RoleId { get; set; }


        }
    }
}