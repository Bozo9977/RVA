using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class banMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BanedUsers",
                table: "BanedUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "BanedUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BanedUsers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BanedUsers",
                table: "BanedUsers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BanedUsers",
                table: "BanedUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BanedUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "BanedUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BanedUsers",
                table: "BanedUsers",
                column: "Username");
        }
    }
}
