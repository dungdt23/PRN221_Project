using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class EnrollRepository : IEnrollRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        EnrollManager manager;
        public EnrollRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<EnrollDTO> GetEnrolls(int groupId)
        {
            manager = new EnrollManager(_context);
            List<Enroll> enrolls = manager.GetEnrolls(groupId);
            List<EnrollDTO> enrollDTOs = _mapper.Map<List<EnrollDTO>>(enrolls);
            return enrollDTOs;
        }
    }
}
