using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MichaelBrandonMorris.Rqtblr.Data.Migrations
{
    public partial class _007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RulesId",
                table: "Ladders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanTieMatch = table.Column<bool>(nullable: false),
                    GamesPerMatch = table.Column<int>(nullable: false),
                    GamesToWinMatch = table.Column<int>(nullable: true),
                    MustWinGameByTwoPoints = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointsToWinGame = table.Column<int>(nullable: false),
                    PointsToWinTiebreaker = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ladders_RulesId",
                table: "Ladders",
                column: "RulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ladders_Rules_RulesId",
                table: "Ladders",
                column: "RulesId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ladders_Rules_RulesId",
                table: "Ladders");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropIndex(
                name: "IX_Ladders_RulesId",
                table: "Ladders");

            migrationBuilder.DropColumn(
                name: "RulesId",
                table: "Ladders");
        }
    }
}
