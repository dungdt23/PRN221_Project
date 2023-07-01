using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.DTO
{
    public class LectureDTO
    {
        public string LectureId { get; set; } = null!;

        public string LectureFirstName { get; set; } = null!;

        public string LectureLastName { get; set; } = null!;

        public int DepartmentId { get; set; }

        public string Email { get; set; } = null!;

        public string? Password { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        public virtual Department Department { get; set; } = null!;
    }
}
