using System;
using System.Collections.Generic;

namespace PRN221_Project1._0.DataAccess.Models;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();
}
