using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityCourse.Data.Migrations
{
    public partial class Adding_Data_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1500, "Nicaraguan League" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachId", "LeagueId", "Name" },
                values: new object[,]
                {
                    { 900, null, 1500, "Esteli" },
                    { 901, null, 1500, "Managua" },
                    { 902, null, 1500, "Walter Ferreti" },
                    { 903, null, 1500, "UNAN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 902);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 903);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1500);
        }
    }
}
