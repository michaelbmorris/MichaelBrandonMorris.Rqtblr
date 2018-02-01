using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MichaelBrandonMorris.Rqtblr.Data.Migrations
{
    public partial class _004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Match_MatchId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Ladders_LadderId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_TeamOneId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_TeamThreeId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_TeamTwoId",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_Match_TeamTwoId",
                table: "Matches",
                newName: "IX_Matches_TeamTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_TeamThreeId",
                table: "Matches",
                newName: "IX_Matches_TeamThreeId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_TeamOneId",
                table: "Matches",
                newName: "IX_Matches_TeamOneId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_LadderId",
                table: "Matches",
                newName: "IX_Matches_LadderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Matches_MatchId",
                table: "Game",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Ladders_LadderId",
                table: "Matches",
                column: "LadderId",
                principalTable: "Ladders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Matches_MatchId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Ladders_LadderId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Team_TeamOneId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Team_TeamThreeId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Team_TeamTwoId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TeamTwoId",
                table: "Match",
                newName: "IX_Match_TeamTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TeamThreeId",
                table: "Match",
                newName: "IX_Match_TeamThreeId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TeamOneId",
                table: "Match",
                newName: "IX_Match_TeamOneId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_LadderId",
                table: "Match",
                newName: "IX_Match_LadderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Match_MatchId",
                table: "Game",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Ladders_LadderId",
                table: "Match",
                column: "LadderId",
                principalTable: "Ladders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_TeamOneId",
                table: "Match",
                column: "TeamOneId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_TeamThreeId",
                table: "Match",
                column: "TeamThreeId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_TeamTwoId",
                table: "Match",
                column: "TeamTwoId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
