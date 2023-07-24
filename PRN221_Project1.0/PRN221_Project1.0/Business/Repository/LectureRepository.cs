using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class LectureRepository : ILectureRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        private LectureManager manager;
        public LectureRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<LectureDTO> GetAllLectures()
        {
            manager = new LectureManager(_context);
            List<Lecture> lectures = manager.GetLectures();
            List<LectureDTO> lectureDTOs = _mapper.Map<List<LectureDTO>>(lectures);
            return lectureDTOs;
        }

        public LectureDTO GetLecture(string username, string password)
        {
            manager = new LectureManager(_context);
            Lecture lecture = manager.GetLecture(username, password);
            LectureDTO lectureDTO = _mapper.Map<LectureDTO>(lecture);
            return lectureDTO;
        }
    }
}
