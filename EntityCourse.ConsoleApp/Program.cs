using EntityCourse.Data.DatabaseContext;
using EntityCourse.Domain.Models;

void Test()
{
    FootballLeagueDbContext dbContext = new FootballLeagueDbContext();
    var record = new League("Geek League");
    dbContext.Leagues.Add(record);
    dbContext.SaveChanges();

    Console.ReadKey();
}


Test();
