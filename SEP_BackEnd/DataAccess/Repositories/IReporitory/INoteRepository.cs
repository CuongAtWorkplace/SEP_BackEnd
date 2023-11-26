using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IReporitory
{
    public interface INoteRepository
    {
        IEnumerable<NoteTeacher> GetNoteTeacherList();
        IEnumerable<NoteTeacher> GetNoteByTeacherId(int userId);
        IEnumerable<NoteTeacher> GetNoteOrderDate(int userId);
        void AddNewNoteTeacher(NoteTeacher noteTeacher);
        void UpdateNoteTeacher(NoteTeacher noteTeacher);
        IEnumerable<NoteTeacher> GetNoteInClass(int classId);
    }
}
