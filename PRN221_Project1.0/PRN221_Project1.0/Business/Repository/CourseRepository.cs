using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class CourseRepository : ICourseRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        CourseManager manager;
        public CourseRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CourseDTO> GetAllCourses(string? lectureId, int? subjectId, int? termId, int? campusId)
        {
            manager = new CourseManager(_context);
            List<Course> courses = manager.GetAllCourses(lectureId, subjectId, termId, campusId);
            List<CourseDTO> courseDTOs = _mapper.Map<List<CourseDTO>>(courses);
            return courseDTOs;
        }
        public void CreateCourse(Course course)
        {
            manager = new CourseManager(_context);
            manager.CreateCourse(course);
        }
    }
}
