﻿using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class SubjectManager
    {
        Prn221MyAssignmentContext _context;
        public SubjectManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
        }
    }
}
