using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Lecture, LectureDTO>();
            CreateMap<LectureDTO, Lecture>();
        }
    }
}
