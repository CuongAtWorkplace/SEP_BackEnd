using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository _user;

        public ClassController(IUserRepository user, IConfiguration config, DB_SEP490Context db)
        {
            _config = config;
            _db = db;
            _user = user;
        }

        [HttpGet("GetAllClass")]
        public IActionResult GetAllClass()
        {
            var listClass = _db.Classes.ToList();    
            if (listClass == null)
            {
                return NotFound();
            }
            return Ok(listClass);
        }

        [HttpGet("GetClassById/{Classid}")]
        public IActionResult GetClassById(int Classid)
        {
            var listClass = _db.Classes.Where(x => x.ClassId == Classid).ToList();
            if (listClass == null)
            {
                return NotFound();
            }
            return Ok(listClass);
        }

        [HttpGet("GetAllClassDetail")]
        public IActionResult GetAllClassDetail()
        {
            List<ClassDTO> list = new List<ClassDTO>();
            var allClass = _db.Classes.Include(t => t.Teacher).Include(c => c.Course).Include(q => q.Quizze).ToList();
            if (allClass == null)
            {
                return NotFound();
            }
            var result = allClass.Select(x => new ClassDTO()
            {
                ClassId = x.ClassId,
                TeacherId = x.TeacherId,
                TeacherName = x.Teacher.FullName,
                CourseId = x.CourseId,
                CourseName = x.Course.CourseName,
                NumberStudent = x.NumberStudent,
                QuizzeId = x.QuizzeId,
                QuizzeName = x.Quizze.Title,
                Schedule = x.Schedule,
                Fee = x.Fee,
                NumberOfWeek = x.NumberOfWeek,
                NumberPhone = x.NumberPhone,
                Description = x.Description,
                CreateDate = x.CreateDate,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                IsDelete = x.IsDelete,
                TokenClass = x.TokenClass,
            }).ToList();
            return Ok(result);
        }
    }
}
