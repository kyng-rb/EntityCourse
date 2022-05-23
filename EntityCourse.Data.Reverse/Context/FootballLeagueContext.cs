using System;
using System.Collections.Generic;
using EntityCourse.Data.Reverse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCourse.Data.Reverse.Context;

public partial class FootballLeagueContext : DbContext
{
    public FootballLeagueContext()
    {
    }

    public FootballLeagueContext(DbContextOptions<FootballLeagueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<League> Leagues { get; set; } = null!;
    public virtual DbSet<Team> Teams { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=FootballLeague; User=sa; Password=<U53rn@m3kyn6>");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasIndex(e => e.LeagueId, "IX_Teams_LeagueId");

            entity.HasOne(d => d.League)
                .WithMany(p => p.Teams)
                .HasForeignKey(d => d.LeagueId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
