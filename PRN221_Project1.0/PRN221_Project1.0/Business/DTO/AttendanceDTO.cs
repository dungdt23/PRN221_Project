using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.DTO
{
    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }

        public int SessionId { get; set; }

        public string StudentId { get; set; } = null!;

        public bool IsAbsent { get; set; }

        public string Comment { get; set; } = null!;

        public virtual Session Session { get; set; } = null!;

        public virtual StudentDTO Student { get; set; } = null!;
    }
}
