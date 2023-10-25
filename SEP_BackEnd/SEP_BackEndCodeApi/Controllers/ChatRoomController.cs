using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatRoomController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository _user;

        public ChatRoomController(IUserRepository user, IConfiguration config, DB_SEP490Context db)
        {
            _config = config;
            _db = db;
            _user = user;
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

    }
}
