using System;
using System.Collections.Generic;

namespace PRN221_Project1._0.DataAccess.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomCode { get; set; } = null!;

    public int CampusId { get; set; }

    public int Capacity { get; set; }

    public virtual Campus Campus { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
