using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly DB_SEP490Context _db;

        public ReportController(DB_SEP490Context db)
        {
            _db = db;
        }
        [HttpGet("GetToUserFullName/{userId}")]
        public async Task<string> GetToUserFullName(int userId)
        {
            var getUser = await _db.Users.FirstOrDefaultAsync(x => x.UserId == userId);

            if (getUser != null)
            {
                return getUser.FullName;
            }

            return "";
        }
        [HttpGet]
        public async Task<IActionResult>  GetAllReport()
        {
            var GetAllReport = await _db.ReportUsers.Include(x => x.FromUserNavigation).ToListAsync();

            List<ReportUserDTO> result = new List<ReportUserDTO>();
          
            foreach (var item in GetAllReport)
            {
                string toUserFullName = await GetToUserFullName(item.ToUser);
                ReportUserDTO reportUser = new ReportUserDTO
                {
                    ReportUserId = item.ReportUserId,
                    FromUser = item.FromUserNavigation.FullName,
                    ToUser = toUserFullName,
                    Description = item.Description,
                    Reason = item.Reason,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modified = item.Modified,
                    EvidenceImage = item.EvidenceImage,
                    IsChecked = item.IsChecked,
                };
                result.Add(reportUser);
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReportById(int rId)
        {
            var GetAllReport = await _db.ReportUsers.Include(x => x.FromUserNavigation).Where(x => x.ReportUserId == rId).ToListAsync();

            List<ReportUserDTO> result = new List<ReportUserDTO>();

            foreach (var item in GetAllReport)
            {
                string toUserFullName = await GetToUserFullName(item.ToUser);
                ReportUserDTO reportUser = new ReportUserDTO
                {
                    ReportUserId = item.ReportUserId,
                    FromUser = item.FromUserNavigation.FullName,
                    ToUser = toUserFullName,
                    Description = item.Description,
                    Reason = item.Reason,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modified = item.Modified,
                    EvidenceImage = item.EvidenceImage,
                    IsChecked = item.IsChecked,
                };
                result.Add(reportUser);
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult>  GetAllReportUserId(int rId)
        {

            var GetAllReport = await _db.ReportUsers.Include(x => x.FromUserNavigation).Where(x => x.ToUser == rId).ToListAsync();

            List<ReportUserDTO> result = new List<ReportUserDTO>();

            foreach (var item in GetAllReport)
            {
                string toUserFullName = await GetToUserFullName(item.ToUser);
                ReportUserDTO reportUser = new ReportUserDTO
                {
                    ReportUserId = item.ReportUserId,
                    FromUser = item.FromUserNavigation.FullName,
                    ToUser = toUserFullName,
                    Description = item.Description,
                    Reason = item.Reason,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modified = item.Modified,
                    EvidenceImage = item.EvidenceImage,
                    IsChecked = item.IsChecked,
                };
                result.Add(reportUser);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReportIsChecked()
        {
            var GetAllReport = await _db.ReportUsers.Include(x => x.FromUserNavigation).Where(x => x.IsChecked == true).ToListAsync();

            List<ReportUserDTO> result = new List<ReportUserDTO>();

            foreach (var item in GetAllReport)
            {
                string toUserFullName = await GetToUserFullName(item.ToUser);
                ReportUserDTO reportUser = new ReportUserDTO
                {
                    ReportUserId = item.ReportUserId,
                    FromUser = item.FromUserNavigation.FullName,
                    ToUser = toUserFullName,
                    Description = item.Description,
                    Reason = item.Reason,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modified = item.Modified,
                    EvidenceImage = item.EvidenceImage,
                    IsChecked = item.IsChecked,
                };
                result.Add(reportUser);
            }

            return Ok(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllReportNoChecked()
        {
            var GetAllReport = await _db.ReportUsers.Include(x => x.FromUserNavigation).Where(x => x.IsChecked == false).ToListAsync();

            List<ReportUserDTO> result = new List<ReportUserDTO>();

            foreach (var item in GetAllReport)
            {
                string toUserFullName = await GetToUserFullName(item.ToUser);
                ReportUserDTO reportUser = new ReportUserDTO
                {
                    ReportUserId = item.ReportUserId,
                    FromUser = item.FromUserNavigation.FullName,
                    ToUser = toUserFullName,
                    Description = item.Description,
                    Reason = item.Reason,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modified = item.Modified,
                    EvidenceImage = item.EvidenceImage,
                    IsChecked = item.IsChecked,
                };
                result.Add(reportUser);
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddReport(ReportUser reportUser)
        {
            try
            {
                ReportUser rp = new ReportUser
                {
                    ReportUserId = reportUser.ReportUserId,
                    FromUser = reportUser.FromUser,
                    ToUser = reportUser.ToUser,
                    Description = reportUser.Description,
                    Reason = reportUser.Reason,
                    CreateDate = reportUser.CreateDate,
                    Status = reportUser.Status,
                    Modified = reportUser.Modified,
                    EvidenceImage = reportUser.EvidenceImage,
                    IsChecked = reportUser.IsChecked,
                };
                _db.ReportUsers.Add(rp);
                _db.SaveChanges();
                return Ok("ok");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        

        [HttpPut]
        public IActionResult UpdateCheckedReport(ReportUser reportUser)
        {
            try
            {
                ReportUser rp = new ReportUser
                {
                    ReportUserId = reportUser.ReportUserId,
                    FromUser = reportUser.FromUser,
                    ToUser = reportUser.ToUser,
                    Description = reportUser.Description,
                    Reason = reportUser.Reason,
                    CreateDate = reportUser.CreateDate,
                    Status = reportUser.Status,
                    Modified = reportUser.Modified,
                    EvidenceImage = reportUser.EvidenceImage,
                    IsChecked = true,
                };
                _db.Entry<ReportUser>(rp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetAllFeedback()
        {
            var GetAllFeedback = _db.Feedbacks.ToList();
            if(GetAllFeedback == null)
            {
                return NotFound();
            }
            List<FeedbackDTO> result = new List<FeedbackDTO>();
            foreach (var item in GetAllFeedback)
            {
                string toUserFullName = await GetToUserFullName(item.FromUserId);
                FeedbackDTO feedbackDTO = new FeedbackDTO
                {
                    FeedbackId = item.FeedbackId,
                    UserName = toUserFullName,
                    Rating = item.Rating,
                    Description = item.Description,
                    CreateDate = item.CreateDate,
                    ModifileDate = item.ModifileDate,
                    IsDelete = item.IsDelete,
                };
                result.Add(feedbackDTO);
              
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbackByFromUserId(int uId)
        {
            var GetAllFeedback = _db.Feedbacks.Where(x=>x.FromUserId == uId).ToList();
            if (GetAllFeedback == null)
            {
                return NotFound();
            }
            List<FeedbackDTO> result = new List<FeedbackDTO>();
            foreach (var item in GetAllFeedback)
            {
                string toUserFullName = await GetToUserFullName(item.FromUserId);
                FeedbackDTO feedbackDTO = new FeedbackDTO
                {
                    FeedbackId = item.FeedbackId,
                    UserName = toUserFullName,
                    Rating = item.Rating,
                    Description = item.Description,
                    CreateDate = item.CreateDate,
                    ModifileDate = item.ModifileDate,
                    IsDelete = item.IsDelete,
                };
                result.Add(feedbackDTO);

            }
            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddFeedback(Feedback feedback)
        {
            try
            {
                Feedback feedback1 = new Feedback
                {
                    FromUserId = feedback.FromUserId,
                    Rating = feedback.Rating,
                    Description = feedback.Description,
                    CreateDate = feedback.CreateDate,
                    ModifileDate = feedback.ModifileDate,
                    IsDelete = feedback.IsDelete,

                };
                _db.Feedbacks.Add(feedback1);
                _db.SaveChanges();
                return Ok("ok");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult AddIsDeleteFeedback(Feedback feedback)
        {
            try
            {
                Feedback feedback1 = new Feedback
                {
                    FeedbackId = feedback.FeedbackId,
                    FromUserId = feedback.FromUserId,
                    Rating = feedback.Rating,
                    Description = feedback.Description,
                    CreateDate = feedback.CreateDate,
                    ModifileDate = feedback.ModifileDate,
                    IsDelete = true,

                };
                _db.Entry<Feedback>(feedback1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                return Ok("ok");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public class FeedbackDTO
        {
            public int FeedbackId { get; set; }
            public string UserName { get; set; }
            public int? Rating { get; set; }
            public string? Description { get; set; }
            public DateTime? CreateDate { get; set; }
            public DateTime? ModifileDate { get; set; }
            public bool? IsDelete { get; set; }
        }
        public class ReportUserDTO
        {
            public int ReportUserId { get; set; }
            public string? FromUser { get; set; }
            public string? ToUser { get; set; }
            public string? Description { get; set; }
            public string? Reason { get; set; }
            public DateTime? CreateDate { get; set; }
            public string? Status { get; set; }
            public DateTime? Modified { get; set; }
            public string? EvidenceImage { get; set; }
            public bool? IsChecked { get; set; }
        }
    }
}
