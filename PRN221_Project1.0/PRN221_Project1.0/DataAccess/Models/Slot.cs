using System;
using System.Collections.Generic;

namespace PRN221_Project1._0.DataAccess.Models;

public partial class Slot
{
    public int SlotId { get; set; }

    public string? SlotName { get; set; }

    public string? Start { get; set; }

    public string? Finish { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
