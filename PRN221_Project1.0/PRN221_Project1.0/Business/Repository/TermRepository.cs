using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class TermRepository : ITermRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        TermManager manager;
        public TermRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<TermDTO> GetAllTerms()
        {
            manager = new TermManager(_context);
            List<Term> terms = manager.GetAllTerms();
            List<TermDTO> termDTOs = _mapper.Map<List<TermDTO>>(terms);
            return termDTOs;
        }
    }
}
