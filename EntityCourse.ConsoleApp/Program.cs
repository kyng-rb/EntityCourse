using EntityCourse.Data.DatabaseContext;
using EntityCourse.Domain.Models;
using Microsoft.EntityFrameworkCore;

async Task Test()
{
    //FootballLeagueDbContext dbContext = new FootballLeagueDbContext();
    //var record = new League("Geek League");
    //dbContext.Leagues.Add(record);
    //dbContext.SaveChanges();

    //InsertManyTeams();
    //InsertRelated();

    await Retrieve();
    await RetrieveWithFilter();
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

async Task Retrieve()
{
    FootballLeagueDbContext dbContext = new FootballLeagueDbContext();

    var leagues = await dbContext.Leagues.ToListAsync();
    foreach (var league in leagues)
    {
        Console.WriteLine($"{league.Id} - {league.Name}");
    }
}

async Task RetrieveWithFilter()
{
    FootballLeagueDbContext dbContext = new FootballLeagueDbContext();

    var criteria = "Premier";
    var allLeagues = await dbContext.Leagues.Where(x => x.Name.Equals(criteria)).ToListAsync();
    foreach (var league in allLeagues)
    {
        Console.WriteLine($"{league.Id} - {league.Name}");
    }

    Console.WriteLine("Insert League Name");
    var name = Console.ReadLine();

    var leagues = await dbContext.Leagues.Where(x => x.Name.Equals(name)).ToListAsync();
    foreach (var league in leagues)
    {
        Console.WriteLine($"{league.Id} - {league.Name}");
    }

    Console.WriteLine("Insert League Name Criteria");
    string leagueNameCriteria = Console.ReadLine() ?? "";

    var leagues2 = await dbContext.Leagues.Where(x => x.Name.Contains(leagueNameCriteria)).ToListAsync();
    foreach (var league in leagues)
    {
        Console.WriteLine($"{league.Id} - {league.Name}");
    }

    Console.WriteLine("Insert Second League Name Criteria");
    string leagueNameCriteria2 = Console.ReadLine() ?? "";

    var leagues3 = await dbContext.Leagues.Where(x => x.Name.Contains(leagueNameCriteria2)).ToListAsync();
    foreach (var league in leagues)
    {
        Console.WriteLine($"{league.Id} - {league.Name}");
    }
}

await Test();
