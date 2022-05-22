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

    //await Retrieve();
    //await RetrieveWithFilter();
    //await ExecutionMethods();
    //await SingleUpdate();
    await UpSert();
    Console.ReadLine();
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

async Task ExecutionMethods()
{
    FootballLeagueDbContext dbContext = new FootballLeagueDbContext();

    var criteria = "A";

    var setList = dbContext.Leagues;
    var leagues = dbContext.Leagues.ToList();

    foreach (var item in setList)
    {
        Console.WriteLine($"{item.Id} - {item.Name}");
    }

    foreach (var item in leagues)
    {
        Console.WriteLine($"{item.Id} - {item.Name}");
    }

    var filtered = dbContext.Leagues.Where(x => x.Name.Contains(criteria)).FirstOrDefault();
    var filtered2 = dbContext.Leagues.FirstOrDefault(x => x.Name.Contains(criteria));
}

async Task SingleUpdate()
{
    var dbContext = new FootballLeagueDbContext();

    var recordId = 3;

    var league = await dbContext.Leagues.FindAsync(recordId);

    league.Name = "FL";

    dbContext.SaveChanges();

    league.Name = "FL";

    dbContext.SaveChanges();//When the save changes function is called, it checks if actually needs execute a database update
                            //in case of not, it does nothing
};

async Task UpSert()
{
    ///We have the Update function which basically works as an upsert
    ///Based on the record id or primary key of the entity it checks
    ///if the records exists, if it does, it is updated in case of not
    ///it is added.

    var dbContext = new FootballLeagueDbContext();

    var newTeam = new Team("Laa City") { LeagueId = 2 };
    var existingTeam = new Team("ABC") { Id = 4, LeagueId = 2 };

    dbContext.Update(newTeam);
    dbContext.Update(existingTeam);

    await dbContext.SaveChangesAsync();
};

await Test();
