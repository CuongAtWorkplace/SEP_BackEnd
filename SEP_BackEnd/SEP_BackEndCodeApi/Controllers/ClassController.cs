using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet("GetAllClass/{Num}")]
        public IActionResult GetAllClassWithCourse(int Num)
        {
            var randomClassesWithCourse = Enumerable.Empty<object>();

            if (Num == 0)
            {
                randomClassesWithCourse = _db.Classes
                    .Join(
                        _db.Courses,
                        classObj => classObj.CourseId,
                        course => course.CourseId,
                        (classObj, course) => new
                        {
                            ClassId = classObj.ClassId,
                            ClassName = classObj.ClassName,
                            courseId = classObj.CourseId,
                            CourseName = course.CourseName,
                        })
                    .ToList();
            }
            else
            {
                randomClassesWithCourse = _db.Classes
                    .OrderBy(x => Guid.NewGuid())
                    .Take(Num + 1)
                    .Join(
                        _db.Courses,
                        classObj => classObj.CourseId,
                        course => course.CourseId,
                        (classObj, course) => new
                        {
                            ClassId = classObj.ClassId,
                            ClassName = classObj.ClassName,
                            courseId = classObj.CourseId,
                            CourseName = course.CourseName,
                        })
                    .ToList();
            }

            if (randomClassesWithCourse.Any())
            {
                return Ok(randomClassesWithCourse);
            }
            else
            {
                return NotFound();
            }
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

        //danh sach lop hoc cua giao vien do
        [HttpGet("{userId}")]
        public IActionResult GetTeacherClassList(int userId)
        {
            try
            {
                var allClass = _db.Classes.Include(t => t.Teacher).
                    Include(c => c.Course).Include(q => q.Quizze).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                var result = allClass.Where(u => u.TeacherId == userId).Select(x => new ClassDTO()
                {
                    ClassId = x.ClassId, ClassName = x.ClassName,
                    TeacherId = x.TeacherId, TeacherName = x.Teacher.FullName,
                    CourseId = x.CourseId, CourseName = x.Course.CourseName,
                    NumberStudent = x.NumberStudent, Topic = x.Topic,
                    QuizzeId = x.QuizzeId, QuizzeName = x.Quizze.Title,
                    Schedule = x.Schedule, Fee = x.Fee, NumberOfWeek = x.NumberOfWeek, NumberPhone = x.NumberPhone,
                    Description = x.Description, CreateDate = x.CreateDate, StartDate = x.StartDate, 
                    EndDate = x.EndDate, Status = x.Status, IsDelete = x.IsDelete, TokenClass = x.TokenClass
                }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //chi tiet lop hoc cua giao vien do
        [HttpGet("{classId}")]
        public IActionResult GetTeacherClassDetail(int classId)
        {
            try
            {
                var allClass = _db.Classes.Include(t => t.Teacher).
                    Include(c => c.Course).Include(q => q.Quizze).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                var result = allClass.Where(cd => cd.ClassId == classId).Select(x => new ClassDTO()
                {
                    ClassId = x.ClassId, ClassName = x.ClassName,
                    TeacherId = x.TeacherId, TeacherName = x.Teacher.FullName,
                    CourseId = x.CourseId, CourseName = x.Course.CourseName,
                    NumberStudent = x.NumberStudent, Topic = x.Topic,
                    QuizzeId = x.QuizzeId, QuizzeName = x.Quizze.Title,
                    Schedule = x.Schedule, Fee = x.Fee, NumberOfWeek = x.NumberOfWeek, NumberPhone = x.NumberPhone, 
                    Description = x.Description, CreateDate = x.CreateDate, StartDate = x.StartDate, 
                    EndDate = x.EndDate, Status = x.Status, IsDelete = x.IsDelete, TokenClass = x.TokenClass
                }).FirstOrDefault();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //top lop hoc moi
        [HttpGet("GetTopClassByDate")]
        public IActionResult GetTopClassByDate()
        {
            try
            {
                var allClass = _db.Classes.Include(t => t.Teacher).
                    Include(c => c.Course).Include(q => q.Quizze).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                var result = allClass.OrderBy(ob => ob.CreateDate).Take(5).Select(x => new ClassDTO()
                {
                    ClassId = x.ClassId, ClassName = x.ClassName,
                    TeacherId = x.TeacherId, TeacherName = x.Teacher.FullName,
                    CourseId = x.CourseId, CourseName = x.Course.CourseName,
                    NumberStudent = x.NumberStudent, Topic = x.Topic,
                    QuizzeId = x.QuizzeId, QuizzeName = x.Quizze.Title,
                    Schedule = x.Schedule, Fee = x.Fee, NumberOfWeek = x.NumberOfWeek, NumberPhone = x.NumberPhone,
                    Description = x.Description, CreateDate = x.CreateDate, StartDate = x.StartDate, 
                    EndDate = x.EndDate, Status = x.Status, IsDelete = x.IsDelete, TokenClass = x.TokenClass
                }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //top lop hoc
        [HttpGet("GetTopClassBy")]
        public IActionResult GetTopClassBy()
        {
            try
            {
                var allClass = _db.Classes.Include(t => t.Teacher).
                    Include(c => c.Course).Include(q => q.Quizze).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                var result = allClass.OrderBy(ob => ob.CreateDate).Take(5).Select(x => new ClassDTO()
                {
                    ClassId = x.ClassId, ClassName = x.ClassName,
                    TeacherId = x.TeacherId, TeacherName = x.Teacher.FullName,
                    CourseId = x.CourseId, CourseName = x.Course.CourseName,
                    NumberStudent = x.NumberStudent, Topic = x.Topic,
                    QuizzeId = x.QuizzeId, QuizzeName = x.Quizze.Title,
                    Schedule = x.Schedule, Fee = x.Fee, NumberOfWeek = x.NumberOfWeek, NumberPhone = x.NumberPhone,
                    Description = x.Description, CreateDate = x.CreateDate, StartDate = x.StartDate,
                    EndDate = x.EndDate, Status = x.Status, IsDelete = x.IsDelete, TokenClass = x.TokenClass
                }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //chinh sua thong tin lop hoc*
        [HttpPut]
        public IActionResult EditClass(Class eClass)
        {
            try
            {
                Class c = _db.Classes.FirstOrDefault(n => n.ClassId == eClass.ClassId);
                if (c is null)
                {
                    return StatusCode(444, "Class is not found");
                }
                else
                {
                    c.ClassName = eClass.ClassName;
                    c.Topic = eClass.Topic;
                    c.QuizzeId = eClass.QuizzeId;
                    c.Schedule = eClass.Schedule;
                    c.Fee = eClass.Fee;
                    c.NumberOfWeek = eClass.NumberOfWeek;
                    c.NumberPhone = eClass.NumberPhone;
                    c.Description = eClass.Description;
                    c.StartDate = eClass.StartDate;
                    c.EndDate = eClass.EndDate;
                    _db.Classes.Update(c);
                    int result = _db.SaveChanges();
                    return Ok(result);
                }
            }
            catch
            {
                return Conflict();
            }
        }

        //tim kiem lop hoc bang ten hoac chu de*
        [HttpGet("{text}")]
        public ActionResult<Class> SearchClass(string text)
        {
            List<Class> classs = _db.Classes.Where(c => c.ClassName.Contains(text) || c.Topic.Contains(text)).ToList();
            if (classs is null) return NotFound();
            else return Ok(classs);
        }

        //danh sach tat ca cac lop hoc (manager)*
        [HttpGet]
        public IActionResult GetListClass()
        {
            try
            {
                var allClass = _db.Classes.Include(t => t.Teacher).
                    Include(c => c.Course).Include(q => q.Quizze).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                var result = allClass.Select(x => new ClassDTO()
                {
                    ClassId = x.ClassId,
                    ClassName = x.ClassName,
                    TeacherId = x.TeacherId,
                    TeacherName = x.Teacher.FullName,
                    CourseId = x.CourseId,
                    CourseName = x.Course.CourseName,
                    NumberStudent = x.NumberStudent,
                    Topic = x.Topic,
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
                    TokenClass = x.TokenClass
                }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //chi tiet lop hoc (manager)*
        [HttpGet("{classId}")]
        public IActionResult GetClassDetail(int classId)
        {
            try
            {
                var allClass = _db.Classes.Include(t => t.Teacher).
                    Include(c => c.Course).Include(q => q.Quizze).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                var result = allClass.Where(cd => cd.ClassId == classId).Select(x => new ClassDTO()
                {
                    ClassId = x.ClassId,
                    ClassName = x.ClassName,
                    TeacherId = x.TeacherId,
                    TeacherName = x.Teacher.FullName,
                    CourseId = x.CourseId,
                    CourseName = x.Course.CourseName,
                    NumberStudent = x.NumberStudent,
                    Topic = x.Topic,
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
                    TokenClass = x.TokenClass
                }).FirstOrDefault();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
