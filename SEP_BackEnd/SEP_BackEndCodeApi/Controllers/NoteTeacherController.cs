using BussinessObject.Models;
using BussinessObject.ResourceModel.ViewModel;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

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
            NoteTeacher nt = _db.NoteTeachers.FirstOrDefault(n => n.ClassId == classId);
            if (nt == null)
            {
                NoteTeacher noteT = new NoteTeacher
                {
                    ClassId = classId
                };
                _db.NoteTeachers.Add(noteT);
                _db.SaveChanges();
                return Ok(noteT);
            }
            else
            {
                var list = _db.NoteTeachers.FirstOrDefault(n => n.ClassId == classId);
                return Ok(list);
            }
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

        [HttpPut]
        public IActionResult UpdateNoteTeachers(NoteDTO noteTeacher)
        {
            try
            {
                NoteTeacher c = _db.NoteTeachers.FirstOrDefault(n => n.NoteId == noteTeacher.NoteId);
                if (c is null)
                {
                    return StatusCode(444, "Note is not found");
                }
                else
                {
                    c.UserId = noteTeacher.UserId;
                    c.ClassId = noteTeacher.ClassId;
                    c.Content = noteTeacher.Content;
                    _db.NoteTeachers.Update(c);
                    int result = _db.SaveChanges();
                    return Ok(result);
                }
            }
            catch
            {
                return Conflict();
            }
        }

    }
}
