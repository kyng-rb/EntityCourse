using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCourse.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityCourse.Data.DataSeeds
{
    public class TeamsConfiguration : IEntityTypeConfiguration<Domain.Models.Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(new List<Team>()
            {
                new Team("Esteli")
                {
                    Id = 900,
                    LeagueId = 1500
                },
                new Team("Managua")
                {
                    Id = 901,
                    LeagueId = 1500
                },
                new Team("Walter Ferreti")
                {
                    Id = 902,
                    LeagueId = 1500
                },
                new Team("UNAN")
                {
                    Id = 903,
                    LeagueId = 1500
                },
            });
        }
    }
}
