using System;
using System.Collections.Generic;

namespace PRN221_Project1._0.DataAccess.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseCode { get; set; } = null!;

    public string LectureId { get; set; } = null!;

    public int SubjectId { get; set; }

    public int TermId { get; set; }

    public int CampusId { get; set; }

    public virtual Campus Campus { get; set; } = null!;

    public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual Lecture Lecture { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Term Term { get; set; } = null!;
}
