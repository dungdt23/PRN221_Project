namespace PRN221_Project1._0.Business.DTO
{
    public class SubjectDTO
    {
        public int SubjectId { get; set; }

        public string SubjectCode { get; set; } = null!;

        public string SubjectName { get; set; } = null!;

        public int DepartmentId { get; set; }
    }
}
