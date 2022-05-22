using EntityCourse.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityCourse.Data.DatabaseContext
{

    public class FootballLeagueDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=FootballLeague; User=sa; Password=U53rn@m3kyn6")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        public DbSet<Team> Teams => Set<Team>();
        public DbSet<League> Leagues => Set<League>();
    }
}
