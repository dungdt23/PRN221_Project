using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.IRepository
{
    public interface IGroupRepository
    {
        GroupDTO GetGroup(int sessionId);
        List<GroupDTO> GetGroups(string lectureId);
        List<GroupDTO> GetGroupsByLectureTerm(string? lectureId, int? termId);
        void CreateGroup(Group group);
        bool IsStarted(int groupId);
        List<GroupDTO> GetAllGroups();
        LectureDTO GetLecture(int groupId);
    }
}
