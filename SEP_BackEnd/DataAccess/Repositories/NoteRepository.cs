using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class NoteRepository : INoteRepository
    {
        public void AddNewNoteTeacher(NoteTeacher noteTeacher) => NoteManagement.Instance.AddNewNoteTeacher(noteTeacher);

        public IEnumerable<NoteTeacher> GetNoteByTeacherId(int userId) => NoteManagement.Instance.GetNoteByTeacherId(userId);

        public IEnumerable<NoteTeacher> GetNoteInClass(int classId) => NoteManagement.Instance.GetNoteInClass(classId);

        public IEnumerable<NoteTeacher> GetNoteOrderDate(int userId) => NoteManagement.Instance.GetNoteOrderDate(userId);

        public IEnumerable<NoteTeacher> GetNoteTeacherList() => NoteManagement.Instance.GetNoteTeacherList();

        public void UpdateNoteTeacher(NoteTeacher noteTeacher) => NoteManagement.Instance.UpdateNoteTeacher(noteTeacher);
    }
}
