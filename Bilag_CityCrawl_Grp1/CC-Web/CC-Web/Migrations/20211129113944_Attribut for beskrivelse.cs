using Microsoft.EntityFrameworkCore.Migrations;

namespace CC_Web.Migrations
{
    public partial class Attributforbeskrivelse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beskrivelse",
                table: "virksomheder",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beskrivelse",
                table: "virksomheder");
        }
    }
}
