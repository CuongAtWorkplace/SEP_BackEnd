using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public void AddNewCourse(Course course) => CourseManagement.Instance.AddNewCourse(course);

        public Course CourseFirst() => CourseManagement.Instance.CourseFirst();

        public void Delete(Course Course) => CourseManagement.Instance.Delete(Course);

        public Course getCourseById(int courseId) => CourseManagement.Instance.getCourseById(courseId);

        public IEnumerable<Course> GetCourseList() => CourseManagement.Instance.GetCourseList();

        public IEnumerable<Course> getCourseByName(string nameCourse) => CourseManagement.Instance.getCourseByName(nameCourse);

        public void Update(Course course) => CourseManagement.Instance.Update(course);
    }
}
