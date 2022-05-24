using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCourse.Domain.Models;

public class Match
{
    public int Id { get; set; }
    public int HomeTeamId { get; set; }
    public virtual Team HomeTeam { get; set; } = null!;
    public int AwayTeamId { get; set; }
    public virtual Team AwayTeam { get; set; } = null!;
    public int LeagueId { get; set; }
    public virtual League League { get; set; } = null!;
    public DateTime Date { get; set; }
}
