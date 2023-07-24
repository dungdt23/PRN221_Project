using Microsoft.EntityFrameworkCore;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class CourseManager
    {
        Prn221MyAssignmentContext _context;
        public CourseManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Course> GetAllCourses(string? lectureId, int? subjectId, int? termId, int? campusId)
        {
            IQueryable<Course> query = _context.Courses.Include(s => s.Lecture).Include(s => s.Subject).Include(s => s.Term).Include(s => s.Campus);
            if (!string.IsNullOrEmpty(lectureId))
            {
                query = query.Where(s => s.LectureId.Equals(lectureId));
            }
            if (subjectId.HasValue)
            {
                query = query.Where(s => s.SubjectId == subjectId);
            }
            if (termId.HasValue)
            {
                query = query.Where(s => s.TermId == termId.Value);
            }
            if (campusId.HasValue)
            {
                query = query.Where(s => s.CampusId == campusId.Value);
            }
            return query
                .ToList();
        }
        public void CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
    }
}
