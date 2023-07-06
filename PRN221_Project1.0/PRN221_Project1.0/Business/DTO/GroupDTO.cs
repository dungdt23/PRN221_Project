using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.DTO
{
    public class GroupDTO
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; } = null!;

        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
