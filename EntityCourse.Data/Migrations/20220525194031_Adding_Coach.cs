﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityCourse.Data.Migrations;

public partial class Adding_Coach : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "CoachId",
            table: "Teams",
            type: "int",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "Coaches",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TeamId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Coaches", x => x.Id);
                table.ForeignKey(
                    name: "FK_Coaches_Teams_TeamId",
                    column: x => x.TeamId,
                    principalTable: "Teams",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Coaches_TeamId",
            table: "Coaches",
            column: "TeamId",
            unique: true,
            filter: "[TeamId] IS NOT NULL");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Coaches");

        migrationBuilder.DropColumn(
            name: "CoachId",
            table: "Teams");
    }
}
