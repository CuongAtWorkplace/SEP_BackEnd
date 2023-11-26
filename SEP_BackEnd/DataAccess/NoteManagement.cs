using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NoteManagement
    {
        private static NoteManagement instance = null;
        private static readonly object instanceLock = new object();
        private NoteManagement() { }
        public static NoteManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NoteManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<NoteTeacher> GetNoteTeacherList()
        {
            List<NoteTeacher> list = new List<NoteTeacher>();
            try
            {
                var db = new DB_SEP490Context();
                list = db.NoteTeachers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public IEnumerable<NoteTeacher> GetNoteByTeacherId(int userId)
        {
            List<NoteTeacher> list = new List<NoteTeacher>();
            try
            {
                var db = new DB_SEP490Context();
                list = db.NoteTeachers.Where(x => x.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

         public IEnumerable<NoteTeacher> GetNoteInClass(int classId)
        {
            List<NoteTeacher> list = new List<NoteTeacher>();
            try
            {
                var db = new DB_SEP490Context();
                list = db.NoteTeachers.Where(x => x.ClassId == classId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public IEnumerable<NoteTeacher> GetNoteOrderDate(int userId)
        {
            List<NoteTeacher> list = new List<NoteTeacher>();
            try
            {
                var db = new DB_SEP490Context();
                list = db.NoteTeachers.Where(x => x.UserId == userId).OrderBy(x => x.CreateDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public void AddNewNoteTeacher(NoteTeacher noteTeacher)
        {
            try
            {
                var db = new DB_SEP490Context();
               
                db.NoteTeachers.Add(noteTeacher);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateNoteTeacher(NoteTeacher noteTeacher)
        {
            try
            {
                    var db = new DB_SEP490Context();
                    db.Entry<NoteTeacher>(noteTeacher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
