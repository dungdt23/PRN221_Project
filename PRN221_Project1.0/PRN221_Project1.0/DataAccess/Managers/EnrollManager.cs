using Microsoft.EntityFrameworkCore;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class EnrollManager
    {
        Prn221MyAssignmentContext _context;
        public EnrollManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Enroll> GetEnrolls(int groupId)
        {
            try
            {
                List<Enroll> enrolls = _context.Enrolls.Include(s => s.Student).Where(s => s.GroupId == groupId).ToList();
                return enrolls;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public void AddEnroll(string studentId, int groupId)
        {
            Enroll enroll = new Enroll();
            enroll.StudentId = studentId;
            enroll.GroupId = groupId;
            _context.Add(enroll);
            _context.SaveChanges();
        }
        public void RemoveEnroll(string studentId, int groupId)
        {
            Enroll enroll = _context.Enrolls.FirstOrDefault(s => s.StudentId.Equals(studentId) && s.GroupId == groupId);
            if (enroll != null)
            {
                _context.Remove(enroll);
                _context.SaveChanges();
            }
        }
    }
}
