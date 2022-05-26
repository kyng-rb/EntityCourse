using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityCourse.Data.Migrations;

public partial class Adding_SP : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        #region Query

        string query = @"
                CREATE FUNCTION dbo.GetNumberOfMatches (@teamId int)
                returns int
                BEGIN
                    Declare @Result int = (
                    SELECT COUNT(*) Matches
                    FROM   dbo.Matches a 
                    INNER JOIN dbo.Teams b on b.Id = a.AwayTeamId
                    INNER JOIN dbo.Teams c on c.Id = a.HomeTeamId
                    WHERE  a.AwayTeamId = @teamId OR a.HomeTeamId = @TeamId)
                    return @result
                END";

        #endregion

        migrationBuilder.Sql(query);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        #region Query

        string query = @"
                DROP Function dbo.GetNumberOfMatches";

        #endregion

        migrationBuilder.Sql(query);
    }
}
