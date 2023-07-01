using System;
using System.Collections.Generic;

namespace PRN221_Project1._0.DataAccess.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectCode { get; set; } = null!;

    public string SubjectName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Department Department { get; set; } = null!;
}
