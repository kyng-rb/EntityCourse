using EntityCourse.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityCourse.Data.DatabaseContext;

public class FootballLeagueDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=FootballLeague; User=sa; Password=<U53rn@m3kyn6>")
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Team>()
            .HasMany(m => m.AwayMatches)
            .WithOne(x => x.AwayTeam)
            .HasForeignKey(q => q.AwayTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Team>()
            .HasMany(c => c.HomeMatches)
            .WithOne(x => x.HomeTeam)
            .HasForeignKey(q => q.HomeTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Coach>()
            .HasOne(c => c.Team)
            .WithOne(a => a.Coach)
            .HasForeignKey<Coach>(b => b.TeamId)
            .OnDelete(DeleteBehavior.NoAction);
    }


    public virtual DbSet<League> Leagues { get; set; } = null!;
    public virtual DbSet<Team> Teams { get; set; } = null!;
    public virtual DbSet<Match> Matches { get; set; } = null!;
    public virtual DbSet<Coach> Coaches { get; set; } = null!;
}
