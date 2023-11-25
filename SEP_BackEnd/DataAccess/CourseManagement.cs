using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CourseManagement
    {
        private static CourseManagement instance = null;
        private static readonly object instanceLock = new object();
        private CourseManagement() { }
        public static CourseManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CourseManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Course> GetCourseList()
        {
            List<Course> list = new List<Course>();
            try
            {
                var db = new DB_SEP490Context();
                list = db.Courses.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public IEnumerable<Course> getCourseByName(string nameCourse)
        {
            List<Course> listCourseByName = new List<Course>();
            try
            {
                var db = new DB_SEP490Context();
                listCourseByName = db.Courses.Where(x => x.Equals(nameCourse)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCourseByName;
        }

        public IEnumerable<Class> getClassInCourse(int courseId)
        {
            List<Class> listClassInCourse = new List<Class>();
            try
            {
                var db = new DB_SEP490Context();
                listClassInCourse = db.Classes.Where(x => x.CourseId== courseId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listClassInCourse;
        }

        public Course getCourseById(int courseId)
        {
            Course? news = null;
            try
            {
                var db = new DB_SEP490Context();
                news = db.Courses.SingleOrDefault(x => x.CourseId == courseId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }

        public Course CourseFirst()
        {
            try
            {
                Course? news = null;
                var db = new DB_SEP490Context();
                news = db.Courses.OrderByDescending(x => x.CreateDate).FirstOrDefault();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewCourse(Course course)
        {
            try
            {
               
                    var db = new DB_SEP490Context();
                    db.Courses.Add(course);
                    db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Course course)
        {
            try
            {
                Course courseUpdate = getCourseById(course.CourseId);
                if (courseUpdate != null)
                {
                    var db = new DB_SEP490Context();
                    db.Entry<Course>(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCourse(Course Course)
        {
            try
            {
                Course course = getCourseById(Course.CourseId);
                if (course != null)
                {
                    var db = new DB_SEP490Context();
                    Course course1 = new Course
                    {
                        CourseId = course.CourseId,
                        CourseName = course.CourseName,
                        Description = course.Description,
                        CreateDate = course.CreateDate,
                        Image = course.Image,
                        IsDelete = true
                    };
                    db.Entry<Course>(course1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                  
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
