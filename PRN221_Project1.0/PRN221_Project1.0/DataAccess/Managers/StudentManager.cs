using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class StudentManager
    {
        Prn221MyAssignmentContext _context;
        public StudentManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public Student GetStudent(string studentId)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId.Equals(studentId));
        }
        public List<Student> GetStudents(int groupId)
        {
            List<Student> students = new List<Student>();
            EnrollManager enrollManager = new EnrollManager(_context);
            List<Enroll> enrolls = enrollManager.GetEnrolls(groupId);
            foreach (Enroll enroll in enrolls)
            {
                Student student = GetStudent(enroll.StudentId);
                students.Add(student);
            }
            return students;
        }
        public List<Student> GetAllStudents()
        {
            List<Student> students = _context.Students.ToList();
            return students;
        }

    }
}
