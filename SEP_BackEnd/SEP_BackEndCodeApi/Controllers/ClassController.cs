using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;

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
    }
}
