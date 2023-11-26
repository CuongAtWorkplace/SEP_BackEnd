using BussinessObject.Models;
using BussinessObject.ResourceModel.ViewModel;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoteTeacherController : ControllerBase
    {
        private readonly DB_SEP490Context _db;
        private IConfiguration _config;
        private readonly INoteRepository _note;

        private readonly IWebHostEnvironment _env;
        public NoteTeacherController(INoteRepository note, IConfiguration config, DB_SEP490Context db, IWebHostEnvironment env)
        {
            _config = config;
            _db = db;
            _note = note;
            _env = env;
        }
   
        [HttpGet]
        public IActionResult GetNoteTeacherList()
        {
            var list = _note.GetNoteTeacherList();
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetNoteByTeacherId(int userId)
        {
            var list = _note.GetNoteByTeacherId(userId);
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetNoteInClass(int classId)
        {
            var list = _note.GetNoteInClass(classId);
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetNoteOrderDate(int userId)
        {
            var list = _note.GetNoteByTeacherId(userId);
            return Ok(list);
        }
        [HttpPut]
        public IActionResult UpdateNoteTeacher(NoteTeacher noteTeacher)
        {
            _note.UpdateNoteTeacher(noteTeacher);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddNewNoteTeacher(NoteTeacher noteTeacher)
        {
            _note.AddNewNoteTeacher(noteTeacher);
            return Ok();
        }

    }
}
