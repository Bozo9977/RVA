using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelOfAccess",
                table: "Tokens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelOfAccess",
                table: "Gates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelOfAccess",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "LevelOfAccess",
                table: "Gates");
        }
    }
}
