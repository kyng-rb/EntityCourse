using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EntityCourse.Domain.Models;

namespace EntityCourse.Data.DatabaseContext;

public class FootballLeagueDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=FootballLeague; User=sa; Password=<U53rn@m3kyn6>")
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        .EnableSensitiveDataLogging();
    }

    public FootballLeagueDbContext() : base()
    {
        this.ChangeTracker.LazyLoadingEnabled = true;
    }


    public virtual DbSet<League> Leagues { get; set; } = null!;
    public virtual DbSet<Team> Teams { get; set; } = null!;
}
