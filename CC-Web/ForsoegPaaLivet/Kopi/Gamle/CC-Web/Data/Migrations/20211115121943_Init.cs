using Microsoft.EntityFrameworkCore.Migrations;

namespace CC_Web.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brugere",
                columns: table => new
                {
                    BrugerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Foravn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foedselsdag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brugere", x => x.BrugerID);
                });

            migrationBuilder.CreateTable(
                name: "cityCrawls",
                columns: table => new
                {
                    CityCrawlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begivenhed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dato = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityCrawls", x => x.CityCrawlID);
                });

            migrationBuilder.CreateTable(
                name: "virksomheder",
                columns: table => new
                {
                    VirksomhedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVR = table.Column<int>(type: "int", nullable: false),
                    Virksomhedsnavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontaktPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_virksomheder", x => x.VirksomhedID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brugere");

            migrationBuilder.DropTable(
                name: "cityCrawls");

            migrationBuilder.DropTable(
                name: "virksomheder");
        }
    }
}
