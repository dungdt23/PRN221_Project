using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class StudentRepository : IStudentRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        StudentManager manager;
        public StudentRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<StudentDTO> GetStudents(int groupId)
        {
            manager = new StudentManager(_context);
            List<Student> students = manager.GetStudents(groupId);
            List<StudentDTO> studentDTOs = _mapper.Map<List<StudentDTO>>(students);
            return studentDTOs;
        }
        public StudentDTO GetStudent(string studentId)
        {
            manager = new StudentManager(_context);
            Student student = manager.GetStudent(studentId);
            StudentDTO studentDTO = _mapper.Map<StudentDTO>(student);
            return studentDTO;
        }
        public List<StudentDTO> GetAllStudents()
        {
            manager = new StudentManager(_context);
            List<Student> students = manager.GetAllStudents();
            List<StudentDTO> studentDTOs = _mapper.Map<List<StudentDTO>>(students);
            return studentDTOs;
        }



    }
}
