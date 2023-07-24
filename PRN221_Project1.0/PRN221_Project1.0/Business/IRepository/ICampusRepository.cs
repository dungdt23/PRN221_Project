using PRN221_Project1._0.Business.DTO;

namespace PRN221_Project1._0.Business.IRepository
{
    public interface ICampusRepository
    {
        List<CampusDTO> GetAllCampuses();
    }
}
