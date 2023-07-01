using System;
using System.Collections.Generic;

namespace PRN221_Project1._0.DataAccess.Models;

public partial class Term
{
    public int TermId { get; set; }

    public string TermName { get; set; } = null!;

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
