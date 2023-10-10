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

        [HttpGet("{name}")]
        public IActionResult GetClassWithCourseAndClassName(String name)
        {
            var listClass = _db.Classes.Where(x => x.ClassName.Contains(name)).ToList();
            if (listClass == null)
            {
                var listClass2 = _db.Classes.Join( _db.Courses,classItem => classItem.CourseId,course => course.CourseId,(classItem, course) => new
         {
             ClassId = classItem.ClassId,
             ClassName = classItem.ClassName,
             CourseName = course.CourseName,
             CourseId = classItem.CourseId,

                })
     .Where(result => result.CourseName.Contains(name))
     .ToList();

                return Ok(listClass2);
            }
            return Ok(listClass);
        
        }


        [HttpGet("{Order}")]
        public IActionResult GetClassByDate(string Order)
        {
            if (Order.Equals("ascend")) {
                var listClass = _db.Classes.OrderBy(x => x.CreateDate).ToList();
                return Ok(listClass);
            }

            if (Order.Equals("descend"))
            {
                    var listClass = _db.Classes.OrderByDescending(x => x.CreateDate).ToList();
                return Ok(listClass);
            }
            return Ok();
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
            //List<ClassDTO> list = new List<ClassDTO>();
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

        [HttpGet("ClassDetail/{classId}")]
        public IActionResult GetClassDetailById(int classId)
        {
            //List<ClassDTO> list = new List<ClassDTO>();
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



    }
}
