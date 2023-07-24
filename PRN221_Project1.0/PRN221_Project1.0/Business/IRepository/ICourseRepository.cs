using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.IRepository
{
    public interface ICourseRepository
    {
        List<CourseDTO> GetAllCourses(string? lectureId, int? subjectId, int? termId, int? campusId);
        void CreateCourse(Course course);
    }
}
