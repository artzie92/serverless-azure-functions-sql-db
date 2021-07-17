using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Players.Infrastructure.Migrations
{
    public partial class PlayersInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerScore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 250, nullable: false),
                    Score = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScore", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerScore_Login",
                table: "PlayerScore",
                column: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerScore");
        }
    }
}
