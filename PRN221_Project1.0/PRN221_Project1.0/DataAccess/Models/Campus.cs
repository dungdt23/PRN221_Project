using System;
using System.Collections.Generic;

namespace PRN221_Project1._0.DataAccess.Models;

public partial class Campus
{
    public int CampusId { get; set; }

    public string CampusCode { get; set; } = null!;

    public string CampusName { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
