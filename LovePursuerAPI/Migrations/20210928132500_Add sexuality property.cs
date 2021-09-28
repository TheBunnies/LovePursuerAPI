using Microsoft.EntityFrameworkCore.Migrations;

namespace LovePursuerAPI.Migrations
{
    public partial class Addsexualityproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sexuality",
                table: "Users",
                type: "character varying(69)",
                maxLength: 69,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexuality",
                table: "Users");
        }
    }
}
