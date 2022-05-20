using System;
using System.Collections.Generic;

namespace EntityCourse.Data.Reverse.Models
{
    public partial class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int LeagueId { get; set; }

        public virtual League League { get; set; } = null!;
    }
}
