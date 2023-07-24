namespace PRN221_Project1._0.Business.DTO
{
    public class RoomDTO
    {
        public int RoomId { get; set; }

        public string RoomCode { get; set; } = null!;

        public int CampusId { get; set; }

        public int Capacity { get; set; }
    }
}
