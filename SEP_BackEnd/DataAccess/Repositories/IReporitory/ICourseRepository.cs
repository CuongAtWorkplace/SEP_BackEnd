using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IReporitory
{
    public interface ICourseRepository
    {
        void Delete(Course Course);
        void Update(Course course);
        void AddNewCourse(Course course);
        Course CourseFirst();
        Course getCourseById(int courseId); 
        IEnumerable<Course> getCourseByName(string nameCourse);
        IEnumerable<Course> GetCourseList();
        IEnumerable<Class> getClassInCourse(int courseId);
    }
}
