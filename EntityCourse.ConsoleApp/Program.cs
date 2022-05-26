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
    //await UpSert();

    //await Tracking();

    //await RetrieveSingle();

    //await RetrieveView();

    await UsingFunction();
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

    var teamsRecords = dbContext.Teams.ToList();
    var matches = new List<Match>();
    foreach (var item in teamsRecords)
    {
        matches.AddRange(Enumerable.Range(1, teamsRecords.Count).Select(x => new Match()
        {
            HomeTeam = item,
            AwayTeam = teamsRecords.Last(),
            Date = DateTime.UtcNow,
            League = league
        }));
    }

    dbContext.AddRange(matches);
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

async Task RetrieveSingle()
{
    var dbContext = new FootballLeagueDbContext();

    var league = await dbContext.Leagues.OrderBy(x => x.Id).LastAsync();

    Console.WriteLine($"{league.Id} -> {league.Name}");

    foreach (var item in league.Teams)
    {
        Console.WriteLine($"{item.Id} -> {item.Name}");
    }

    foreach (var item in league.Matches)
    {
        Console.WriteLine($"Game Number: {item.Id} -> Home: {item.HomeTeam.Name} vs -> Away: {item.AwayTeam.Name}");
    }
}

async Task Retrieve()
{
    FootballLeagueDbContext dbContext = new FootballLeagueDbContext();

    var leagues = await dbContext.Leagues.ToListAsync();
    foreach (var league in leagues)
    {
        Console.WriteLine($"{league.Id} - {league.Name}");
        foreach (var team in league.Teams)
        {
            Console.WriteLine($"--->{team.Id} - {team.Name}");
        }
    }

    var leagues2 = await dbContext.Leagues.Include(x => x.Teams).ToListAsync();
    foreach (var league in leagues2)
    {
        Console.WriteLine($"{league.Id} - {league.Name}");

        foreach (var team in league.Teams)
        {
            Console.WriteLine($"--->{team.Id} - {team.Name}");
        }
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

async Task Tracking()
{
    ///Tracking vs No Tracking
    ///It is an Entity Feature, in short, when we retrieve a database record EF do a track
    ///for each entity, basically it observes each record change. It is useful when we execute
    ///the function SaveChanges or SaveChangesAsync, because based on that track entity knows
    ///which records should be updated and which properties as well.
    ///It by the way, means that each record with no track won't be updated when we make use
    ///of the function SaveChanges
    ///As No tracking is an extension method of IQueryable interface.

    ///As no tracking feature is useful when we want to show a query result and we won't update it
    ///a get is a good example, we do not need track those records.
    ///

    ///We can change the tracking behavior by modifying the context instance 
    ///context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    var dbContext = new FootballLeagueDbContext();

    var withTrack = dbContext.Leagues.First();
    var withNoTrack = dbContext.Leagues.AsNoTracking().OrderBy(x => x.Id).Last();

    withTrack.Name += " -> Lovely";
    withNoTrack.Name += " -> Not Sexy";

    await dbContext.SaveChangesAsync();

    ///There is a way to add to the track context an entity. Basically we use the ef context and add the 
    ///entity, afterwards we marks it as modified

    dbContext.Attach(withNoTrack).State = EntityState.Modified;
    await dbContext.SaveChangesAsync();

};

async Task RetrieveView()
{
    var dbContext = new FootballLeagueDbContext();

    var teamDetails = await dbContext.TeamDetails.ToListAsync();

    foreach (var item in teamDetails)
    {
        Console.WriteLine($"Name: {item.TeamName} -> League: {item.LeagueName} -> CoachName: {item.CoachName}");
    }
}

async Task UsingFunction()
{
    var dbContext = new FootballLeagueDbContext();

    var team = dbContext.Teams.OrderByDescending(x => x.Id).First();

    int numberOfMatches = await dbContext.Database.ExecuteSqlInterpolatedAsync(@$"
    SELECT COUNT(*) Matches
    FROM   dbo.Matches a
    INNER JOIN dbo.Teams b on b.Id = a.AwayTeamId
    INNER JOIN dbo.Teams c on c.Id = a.HomeTeamId
    WHERE  a.AwayTeamId = {team.Id} OR a.HomeTeamId = {team.Id}
    ");
}

await Test();
