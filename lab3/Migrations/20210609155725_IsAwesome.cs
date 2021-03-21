using Microsoft.EntityFrameworkCore.Migrations;

namespace lab3.Migrations
{
    public partial class IsAwesome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAwesome",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAwesome",
                table: "Persons");
        }
    }
}
