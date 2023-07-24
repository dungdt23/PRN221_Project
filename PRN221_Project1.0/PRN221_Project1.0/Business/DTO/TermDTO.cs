namespace PRN221_Project1._0.Business.DTO
{
    public class TermDTO
    {
        public int TermId { get; set; }

        public string TermName { get; set; } = null!;

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
