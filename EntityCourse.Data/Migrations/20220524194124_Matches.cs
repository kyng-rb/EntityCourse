using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityCourse.Data.Migrations;

public partial class Matches : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Matches",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                HomeTeamId = table.Column<int>(type: "int", nullable: false),
                AwayTeamId = table.Column<int>(type: "int", nullable: false),
                LeagueId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Matches", x => x.Id);
                table.ForeignKey(
                    name: "FK_Matches_Leagues_LeagueId",
                    column: x => x.LeagueId,
                    principalTable: "Leagues",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Matches_Teams_AwayTeamId",
                    column: x => x.AwayTeamId,
                    principalTable: "Teams",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Matches_Teams_HomeTeamId",
                    column: x => x.HomeTeamId,
                    principalTable: "Teams",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Matches_AwayTeamId",
            table: "Matches",
            column: "AwayTeamId");

        migrationBuilder.CreateIndex(
            name: "IX_Matches_HomeTeamId",
            table: "Matches",
            column: "HomeTeamId");

        migrationBuilder.CreateIndex(
            name: "IX_Matches_LeagueId",
            table: "Matches",
            column: "LeagueId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Matches");
    }
}
