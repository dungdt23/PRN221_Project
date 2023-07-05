using System;
using System.Collections.Generic;

namespace PRN221_Project1._0.DataAccess.Models;

public partial class Enroll
{
    public int EnrollId { get; set; }

    public string StudentId { get; set; } = null!;

    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
