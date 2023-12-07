using BussinessObject.Models;
using BussinessObject.ResourceModel.ViewModel;
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

        [HttpGet]
        public IActionResult GetAllClass()
        {
            try
            {
                List<ClassAllDAO> listAllClass = new List<ClassAllDAO>();

                var listJoinUsersClass = _db.Users.Include(x => x.Classes).ToList();
                var listJoinClasCourse = _db.Classes.Include(o => o.Course).Include(o => o.Teacher).ToList();

                foreach (var y in listJoinClasCourse)
                {
                    ClassAllDAO c = new ClassAllDAO
                    {
                        ClassName = y.ClassName,
                        TeacherName = y.Teacher.FullName,
                        CourseName = y.Course.CourseName,
                        Topic = y.Topic,
                        Fee = y.Fee,
                        NumberOfWeek = y.NumberOfWeek,
                        CreateDate = y.CreateDate,
                        Schedule = y.Schedule,
                        NumberPhone = y.NumberPhone,
                        StartDate = y.StartDate,
                        EndDate = y.EndDate,
                        Status = y.Status,
                    };
                    listAllClass.Add(c);
                }

                return Ok(listAllClass);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
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
                            Classname = classObj.ClassName,
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
                            Classname = classObj.ClassName,
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

        //top lop hoc moi, homepage
        [HttpGet]
        public IActionResult GetTopClassByDate()
        {
            try
            {
                var allClass = _db.Classes.Include(t => t.Teacher).Include(c => c.Course).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                var result = allClass.Where(x => x.Teacher != null && x.Course != null)
                    .OrderByDescending(ob => ob.CreateDate).Take(5).Select(x => new ClassDTO()
                    {
                        ClassId = x.ClassId, ClassName = x.ClassName,
                        TeacherId = x.TeacherId, TeacherName = x.Teacher?.FullName,
                        CourseId = x.CourseId, CourseName = x.Course?.CourseName,
                        NumberStudent = x.NumberStudent, Topic = x.Topic, Schedule = x.Schedule,
                        Fee = x.Fee, NumberOfWeek = x.NumberOfWeek, NumberPhone = x.NumberPhone,
                        Description = x.Description, CreateDate = x.CreateDate,
                        StartDate = x.StartDate, EndDate = x.EndDate, Status = x.Status,
                        IsDelete = x.IsDelete, TokenClass = x.TokenClass
                    }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //danh sach lop hoc cua giao vien do, viewclass
        [HttpGet("{userId}")]
        public IActionResult GetClassListForRole(int userId)
        {
            try
            {
                User us = _db.Users.FirstOrDefault(u => u.UserId == userId);
                var allClass = _db.Classes.Include(t => t.Teacher).
                    Include(c => c.Course).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                if (us.RoleId == 1)
                {
                    var result = allClass.Where(u => u.TeacherId == userId).Select(x => new ClassDTO()
                    {
                        ClassId = x.ClassId,
                        ClassName = x.ClassName,
                        TeacherId = x.TeacherId,
                        TeacherName = x.Teacher?.FullName,
                        CourseId = x.CourseId,
                        CourseName = x.Course?.CourseName,
                        NumberStudent = x.NumberStudent,
                        Topic = x.Topic,
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
                else
                {
                    var result = allClass.Select(x => new ClassDTO()
                    {
                        ClassId = x.ClassId,
                        ClassName = x.ClassName,
                        TeacherId = x.TeacherId,
                        TeacherName = x.Teacher?.FullName,
                        CourseId = x.CourseId,
                        CourseName = x.Course?.CourseName,
                        NumberStudent = x.NumberStudent,
                        Topic = x.Topic,
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
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //chi tiet lop hoc cua giao vien do, classdetail
        [HttpGet("{classId}")]
        public IActionResult GetTeacherClassDetail(int classId)
        {
            try
            {
                Class cl = _db.Classes.FirstOrDefault(cla => cla.ClassId == classId);
                if (cl.TeacherId == null)
                {
                    var allClass = _db.Classes.Include(c => c.Course).ToList();
                    if (allClass == null)
                    {
                        return NotFound();
                    }
                    var result = allClass.Where(cd => cd.ClassId == classId).Select(x => new ClassDTO()
                    {
                        ClassId = x.ClassId, ClassName = x.ClassName,
                        CourseId = x.CourseId, CourseName = x.Course.CourseName,
                        Topic = x.Topic, Schedule = x.Schedule, Fee = x.Fee,
                        NumberOfWeek = x.NumberOfWeek, NumberPhone = x.NumberPhone,
                        Description = x.Description, CreateDate = x.CreateDate,
                        Status = x.Status, IsDelete = x.IsDelete, TokenClass = x.TokenClass
                    }).FirstOrDefault();
                    return Ok(result);
                }
                else
                {
                    var allClass = _db.Classes.Include(t => t.Teacher).Include(c => c.Course).ToList();
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
                        Schedule = x.Schedule, Fee = x.Fee, NumberOfWeek = x.NumberOfWeek, 
                        NumberPhone = x.NumberPhone, Description = x.Description, 
                        CreateDate = x.CreateDate, StartDate = x.StartDate, 
                        EndDate = x.EndDate, Status = x.Status, IsDelete = x.IsDelete, 
                        TokenClass = x.TokenClass
                    }).FirstOrDefault();
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //chinh sua thong tin lop hoc
        [HttpPut]
        public IActionResult EditClass(EditClassDTO eClass)
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

        //cac lop hoc chua bat dau
        [HttpGet("{courseId}")]
        public IActionResult GetListEmptyClass(int courseId)
        {
            try
            {
                var allClass = _db.Classes.Include(c => c.Course).ToList();
                if (allClass == null)
                {
                    return NotFound();
                }
                var result = allClass.Where(u => u.CourseId == courseId && u.TeacherId == null).Select(x => new ClassEmptyDTO()
                {
                    ClassId = x.ClassId,
                    ClassName = x.ClassName,
                    CourseId = x.CourseId,
                    CourseName = x.Course.CourseName,
                    Topic = x.Topic,
                    Schedule = x.Schedule,
                    Fee = x.Fee,
                    NumberOfWeek = x.NumberOfWeek,
                    NumberPhone = x.NumberPhone,
                    Description = x.Description,
                    CreateDate = x.CreateDate,
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


        [HttpPut]
        public IActionResult UpdateClassManager(Class classUpdate)
        {
            try
            {
               var checkClass = _db.Classes.Where(x =>x.ClassId== classUpdate.ClassId).FirstOrDefault();
                if (checkClass != null)
                {
                    _db.Entry<Class>(classUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateClassManager(Class classCreate)
        {
            try
            {
                    _db.Classes.Add(classCreate);
                    _db.SaveChanges();
                
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetClassName(int classId)
        {
            try
            {
                string nameClass = _db.Classes.Where(x => x.ClassId == classId).Select(x => x.ClassName).FirstOrDefault();
                return Ok(nameClass);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult CheckUserFromClass(int userId, string className)
        {
            try
            {
                var check = _db.ListStudentClasses.Include(x => x.User).Include(x => x.Class)
                    .Where(x => x.UserId.Equals(userId) && x.Class.ClassName.Equals(className) || x.Class.TeacherId == userId ).FirstOrDefault();
                if (check != null)
                {
                    return Ok("Ok");
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult RequestClass(RequestClassDTO rClass)
        {
            try
            {
                Class c = _db.Classes.FirstOrDefault(n => n.ClassId == rClass.ClassId);
                if (c is null)
                {
                    return StatusCode(444, "Class is not found found ");
                }
                else
                {

                    c.TeacherId = rClass.TeacherId;
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
                    Include(c => c.Course).ToList();
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
                    Include(c => c.Course).ToList();
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

        [HttpPost]
        public IActionResult CreateRequestClassManager(RequestClass requestClass)
        {
            try
            {
                RequestClass list = new RequestClass
                {
                    RequestClassId = requestClass.RequestClassId,
                    ClassId = requestClass.ClassId,
                    UserId = requestClass.UserId,
                    Type = null
                };
                _db.RequestClasses.Add(list);
                _db.SaveChanges();
                return Ok(1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ListRequestClassManager()
        {
            try
            {
                var list = _db.RequestClasses
                    .Include(x=>x.User)
                    .Include(x=>x.Class)
                    .Where(x=>x.Type == null)
                    .Select(x => new ListRequestClassDTO
                    {
                        RequestClassId=x.RequestClassId,
                        ClassId = x.RequestClassId,
                        ClassName= x.Class.ClassName,
                        TeacherId = x.UserId,
                        TeacherName=x.User.FullName,
                    } );
                return Ok(list);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRequestClassManager(int requestId)
        {
            try
            {
                var list = await _db.RequestClasses.Where(x =>x.RequestClassId == requestId).FirstOrDefaultAsync() ;
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateTypeClassRequest(RequestClassTypeDTO requestClass)
        {
            try
            {
                RequestClass Rclass = _db.RequestClasses.FirstOrDefault(x =>x.RequestClassId== requestClass.RequestClassId);
                if (Rclass is null)
                {
                    return StatusCode(444, "Class is not found found ");
                }
                else
                {

                    Rclass.Type = requestClass.Type;
                    _db.RequestClasses.Update(Rclass);
                    int result = _db.SaveChanges();
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
