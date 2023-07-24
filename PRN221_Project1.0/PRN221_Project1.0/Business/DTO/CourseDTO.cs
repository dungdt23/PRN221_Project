using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.DTO
{
    public class CourseDTO
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; } = null!;

        public string CourseCode { get; set; } = null!;

        public string LectureId { get; set; } = null!;

        public int SubjectId { get; set; }

        public int TermId { get; set; }

        public int CampusId { get; set; }
        public virtual CampusDTO Campus { get; set; } = null!;
        public virtual LectureDTO Lecture { get; set; } = null!;

        public virtual SubjectDTO Subject { get; set; } = null!;

        public virtual TermDTO Term { get; set; } = null!;
    }
}
