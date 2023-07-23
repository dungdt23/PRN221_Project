using PRN221_Project1._0.Business.DTO;

namespace PRN221_Project1._0.Business.IRepository
{
    public interface IStudentRepository
    {
        List<StudentDTO> GetStudents(int groupId);
        StudentDTO GetStudent(string studentId);
    }
}
