using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCourse.Domain.Models;

public class TeamDetail
{
    public string TeamName { get; set; } = null!;
    public string LeagueName { get; set; } = null!;
    public string? CoachName { get; set; }
}
