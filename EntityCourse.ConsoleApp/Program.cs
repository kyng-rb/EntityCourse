using EntityCourse.Data.DatabaseContext;
using EntityCourse.Domain.Models;

void Test()
{
    FootballLeagueDbContext dbContext = new FootballLeagueDbContext();
    var record = new League("Geek League");
    dbContext.Leagues.Add(record);
    dbContext.SaveChanges();

    InsertManyTeams();
    InsertRelated();
    Console.ReadKey();
}

void InsertManyTeams()
{
    FootballLeagueDbContext dbContext = new FootballLeagueDbContext();
    var league = new League("Serie A");

    dbContext.Leagues.Add(league);
    dbContext.SaveChanges();

    var teams = new List<Team>() {
        new Team("Juventus") {
            LeagueId = league.Id
        },
        new Team("Internazzionales") {
            League = league
        },
        new Team("Torino") {
            League = league
        }
    };

    dbContext.AddRange(teams);
    dbContext.SaveChanges();
}

void InsertRelated()
{

    FootballLeagueDbContext dbContext = new FootballLeagueDbContext();
    var league = new League("Premier")
    {
        Teams = new List<Team>(){
            new Team("Everton"),
            new Team("Palace"),
            new Team("Chelsea")
        }
    };

    dbContext.Add(league);
    dbContext.SaveChanges();

    var team = new Team("Abc")
    {
        League = new League("Random League")

    };

    dbContext.Add(team);
    dbContext.SaveChanges();
}

Test();
