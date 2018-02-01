using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MichaelBrandonMorris.Rqtblr.Data.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Team_TeamOneId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Team_TeamThreeId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Team_TeamTwoId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Matches_TeamOneId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_TeamThreeId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_TeamTwoId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TeamOneId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TeamThreeId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TeamTwoId",
                table: "Matches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamOneId",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamThreeId",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamTwoId",
                table: "Matches",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerOneId = table.Column<string>(nullable: true),
                    PlayerTwoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_AspNetUsers_PlayerOneId",
                        column: x => x.PlayerOneId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_AspNetUsers_PlayerTwoId",
                        column: x => x.PlayerTwoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamOneId",
                table: "Matches",
                column: "TeamOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamThreeId",
                table: "Matches",
                column: "TeamThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamTwoId",
                table: "Matches",
                column: "TeamTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_PlayerOneId",
                table: "Team",
                column: "PlayerOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_PlayerTwoId",
                table: "Team",
                column: "PlayerTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Team_TeamOneId",
                table: "Matches",
                column: "TeamOneId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Team_TeamThreeId",
                table: "Matches",
                column: "TeamThreeId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Team_TeamTwoId",
                table: "Matches",
                column: "TeamTwoId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
