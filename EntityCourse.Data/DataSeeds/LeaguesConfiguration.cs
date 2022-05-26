using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCourse.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityCourse.Data.DataSeeds;

public class LeaguesConfiguration : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.HasData(new League()
        {
            Name = "Nicaraguan League",
            Id = 1500
        });
    }
}
