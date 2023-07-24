using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        SubjectManager manager;
        public SubjectRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SubjectDTO> GetAllSubjects()
        {
            manager = new SubjectManager(_context);
            List<Subject> subjects = manager.GetSubjects();
            List<SubjectDTO> subjectDTOs = _mapper.Map<List<SubjectDTO>>(subjects);
            return subjectDTOs;
        }
    }
}
