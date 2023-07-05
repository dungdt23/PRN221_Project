﻿using Microsoft.EntityFrameworkCore;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class SessionManager
    {
        Prn221MyAssignmentContext _context;
        public SessionManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Session> GetSessions(string lectureId, DateTime from, DateTime to)
        {
            List<Session> sessions = new List<Session>();
            sessions = _context.Sessions
                                 .Where(s => s.Date >= from && s.Date <= to)
                                 .Include(s => (s as Session).Group)
                                 .ThenInclude(g => (g as Group).Course)
                                 .ThenInclude(c => (c as Course).Lecture)
                                 .Where(s => s.Group.Course.LectureId == lectureId)
                                 .Include(s => s.Room)
                                 .ToList();
            return sessions;
        }
    }
}
