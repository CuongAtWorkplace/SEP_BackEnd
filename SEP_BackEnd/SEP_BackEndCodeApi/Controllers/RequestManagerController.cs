using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequestManagerController : ControllerBase
    {
        private readonly DB_SEP490Context _db;

        public RequestManagerController(DB_SEP490Context db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatRoom([FromBody] ChatRoom chatRoom)
        {
            try
            {
                // Kiểm tra tính hợp lệ của đối tượng chatRoom, kiểm tra null và các điều kiện khác nếu cần
                if (chatRoom == null)
                {
                    return BadRequest("Invalid chat room data");
                }

                // Thêm chatRoom vào DbSet và lưu thay đổi vào cơ sở dữ liệu
                _db.ChatRooms.Add(chatRoom);
                await _db.SaveChangesAsync();

                // Trả về ID của chatRoom trong phản hồi với HTTP Status 201 Created
                return CreatedAtAction(nameof(GetChatRoomById), new { id = chatRoom.ChatRoomId }, chatRoom.ChatRoomId);
            }
            catch (Exception ex)
            {
                // Trả về lỗi nếu có lỗi xảy ra
                return StatusCode(500, "Internal server error");
            }
        }

        // Hàm lấy ChatRoom bởi ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatRoomById(int id)
        {
            try
            {
                // Lấy chatRoom từ cơ sở dữ liệu bằng ID
                var chatRoom = await _db.ChatRooms.FindAsync(id);

                // Kiểm tra xem chatRoom có tồn tại hay không
                if (chatRoom == null)
                {
                    return NotFound(); // Trả về HTTP Status 404 Not Found nếu không tìm thấy chatRoom
                }

                // Trả về thông tin của chatRoom
                return Ok(chatRoom);
            }
            catch (Exception ex)
            {
                // Trả về lỗi nếu có lỗi xảy ra
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("CheckManagerChatRoom/{classId}")]
        public IActionResult CheckManagerChatRoom(int classId)
        {
            try
            {
                // Kiểm tra xem có ChatRoom nào trong classId có thuộc tính isManagerChat là true không
                var isManagerChatRoomExist = _db.ChatRooms
                          .Any(c => c.ChatRoomId == classId && c.IsManagerChat == true);

                return Ok(isManagerChatRoomExist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("ChangeStatus/{classId}")]
        public IActionResult ChangeStatus(int classId)
        {
            try
            {
                // Kiểm tra xem có ChatRoom nào trong classId có thuộc tính isManagerChat là true không
                var isManagerChatRoomExist = _db.ChatRooms
                          .Where(c => c.ChatRoomId == classId);

                return Ok(isManagerChatRoomExist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }



    }
}
