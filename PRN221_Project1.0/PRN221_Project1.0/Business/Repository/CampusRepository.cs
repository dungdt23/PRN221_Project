using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class CampusRepository : ICampusRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        CampusManager manager;
        public CampusRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CampusDTO> GetAllCampuses()
        {
            manager = new CampusManager(_context);
            List<Campus> campuses = manager.GetAllCampuses();
            List<CampusDTO> campusDTOs = _mapper.Map<List<CampusDTO>>(campuses);
            return campusDTOs;
        }
    }
}
