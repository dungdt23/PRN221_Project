using Microsoft.EntityFrameworkCore.Query.Internal;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class LectureManager
    {
        Prn221MyAssignmentContext _context;
        public LectureManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public Lecture GetLecture(string username, string password)
        {
            Lecture lecture = null;
            try
            {
                lecture = (Lecture)_context.Lectures.FirstOrDefault(l => l.Email.Equals(username) && l.Password.Equals(password));
            }
            catch (Exception e)
            {

            }
            return lecture;
        }
        public List<Lecture> GetLectures()
        {
            return _context.Lectures.ToList();
        }
    }
}
