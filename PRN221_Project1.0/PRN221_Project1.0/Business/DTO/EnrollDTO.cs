using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.DTO
{
    public class EnrollDTO
    {
        public int EnrollId { get; set; }

        public string StudentId { get; set; } = null!;

        public int GroupId { get; set; }
        public virtual StudentDTO Student { get; set; } = null!;


    }
}
