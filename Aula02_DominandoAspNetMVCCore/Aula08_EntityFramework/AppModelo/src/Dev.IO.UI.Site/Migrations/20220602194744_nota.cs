using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.IO.UI.Site.Migrations
{
    public partial class nota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nota",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nota",
                table: "Alunos");
        }
    }
}
