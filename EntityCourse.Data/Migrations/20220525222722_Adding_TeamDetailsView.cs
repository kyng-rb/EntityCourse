using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityCourse.Data.Migrations;

public partial class Adding_TeamDetailsView : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        #region Query

        string query = @"Create View dbo.[TeamDetails] as
                           Select a.Name TeamName,
                                   b.Name LeagueName,
                                   c.Name CoachName
                           FROM   dbo.Teams a 
                           inner join dbo.Leagues b on b.Id = a.LeagueId
                           left join dbo.Coaches c on c.TeamId = a.Id";

        #endregion

        migrationBuilder.Sql(query);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

        #region Query

        string query = @"Drop View dbo.TeamDetails";

        #endregion

        migrationBuilder.Sql(query);
    }
}
