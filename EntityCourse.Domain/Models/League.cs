using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCourse.Domain.Models;

public class League
{
    public League(string name)
    {
        Name = name;
        Teams = new HashSet<Team>();
    }

    public League()
    {

        Teams = new HashSet<Team>();
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Team> Teams { get; set; }
}
