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
    }

    public int Id { get; set; }
    public string Name { get; set; }
}
