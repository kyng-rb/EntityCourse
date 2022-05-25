using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCourse.Domain.Models;

public class Coach
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }
}
