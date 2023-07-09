using Microsoft.EntityFrameworkCore;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class AttendanceManager
    {
        Prn221MyAssignmentContext _context;
        public AttendanceManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Attendance> GetAttendance(int sessionId)
        {
            return _context.Attendances.Where(s => s.SessionId == sessionId)
                                        .Include(s => s.Student)
                                        .ToList();
        }
        public void TakeAttendance(int attendanceId, bool status)
        {
            Attendance attendance = _context.Attendances.FirstOrDefault(s => s.AttendanceId == attendanceId);
            if (attendance != null)
            {
                attendance.IsAbsent = status;
            }
            _context.SaveChanges();
        }
        public Dictionary<string, float> GetAttendances(int groupId)
        {
            SessionManager sessionManager = new SessionManager(_context);
            List<Session> sessions = sessionManager.AttendedSession(groupId);
            Dictionary<string, float> result = new Dictionary<string, float>();
            StudentManager studentManager = new StudentManager(_context);
            // get all student in that session
            List<Student> students = studentManager.GetStudents(groupId);
            foreach (Student student in students)
            {
                // Set the key of the dictionary to be the student ID
                string studentId = student.StudentId.ToString();

                // Set the value of the dictionary to some float value
                float value = 0.0f;
                result[studentId] = value;
            }

            foreach (Session s in sessions)
            {
                //get list of attendance belong to session
                List<Attendance> attendances = this.GetAttendance(s.SessionId);
                //loop all student in that session
                foreach (Student student in students)
                {
                    int absentCount = 0;
                    foreach (var a in attendances)
                    {
                        if (a.StudentId.Equals(student.StudentId))
                        {
                            if (a.IsAbsent)
                            {
                                absentCount++;
                            }
                        }
                    }
                    //get percentage of absent
                    float percentage = (float)absentCount / 5;
                    result[student.StudentId] = percentage * 100;
                }
            }


            return result;
        }
    }
}
