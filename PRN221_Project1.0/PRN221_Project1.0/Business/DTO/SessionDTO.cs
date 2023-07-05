using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.DTO
{
    public class SessionDTO
    {
        public int SessionId { get; set; }

        public int GroupId { get; set; }

        public DateTime Date { get; set; }

        public int SlotId { get; set; }

        public int RoomId { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        public virtual Group Group { get; set; } = null!;

        public virtual Room Room { get; set; } = null!;
        public bool? IsAttended { get; set; }

        public virtual Slot Slot { get; set; } = null!;
    }
}
