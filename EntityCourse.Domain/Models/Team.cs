using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCourse.Domain.Models;

public class Team
{
    public Team(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int LeagueId { get; set; }
    public int? CoachId { get; set; }

    public virtual Coach? Coach { get; set; }
    public virtual League League { get; set; } = null!;
    public virtual ICollection<Match> HomeMatches { get; set; } = null!;
    public virtual ICollection<Match> AwayMatches { get; set; } = null!;
}
