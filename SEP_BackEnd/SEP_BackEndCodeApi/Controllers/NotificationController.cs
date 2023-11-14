using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository _user;

        public NotificationController(IUserRepository user, IConfiguration config, DB_SEP490Context db)
        {
            _config = config;
            _db = db;
            _user = user;
        }

        [HttpGet]
        public IActionResult GetNotificationByUser(int userId)
        {
            try
            {
                var allNoti = _db.NotificationUsers.Include(u => u.User).
                    Include(c => c.Notification).ToList();
                if (allNoti == null)
                {
                    return NotFound();
                }
                var result = allNoti.Where(n => n.UserId == userId).Select(x => new NotificationDTO()
                {
                    NotificationUserId = x.NotificationUserId,
                    UserId = x.UserId,
                    NotificationId = x.NotificationId,
                    Title = x.Notification.Title,
                    Description = x.Notification.Description,
                    CreateDate = x.Notification.CreateDate
                }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
