using Microsoft.EntityFrameworkCore.Migrations;

namespace CC_Web.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityCrawlID",
                table: "virksomheder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityCrawlID",
                table: "brugere",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_virksomheder_CityCrawlID",
                table: "virksomheder",
                column: "CityCrawlID");

            migrationBuilder.CreateIndex(
                name: "IX_brugere_CityCrawlID",
                table: "brugere",
                column: "CityCrawlID");

            migrationBuilder.AddForeignKey(
                name: "FK_brugere_cityCrawls_CityCrawlID",
                table: "brugere",
                column: "CityCrawlID",
                principalTable: "cityCrawls",
                principalColumn: "CityCrawlID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_virksomheder_cityCrawls_CityCrawlID",
                table: "virksomheder",
                column: "CityCrawlID",
                principalTable: "cityCrawls",
                principalColumn: "CityCrawlID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brugere_cityCrawls_CityCrawlID",
                table: "brugere");

            migrationBuilder.DropForeignKey(
                name: "FK_virksomheder_cityCrawls_CityCrawlID",
                table: "virksomheder");

            migrationBuilder.DropIndex(
                name: "IX_virksomheder_CityCrawlID",
                table: "virksomheder");

            migrationBuilder.DropIndex(
                name: "IX_brugere_CityCrawlID",
                table: "brugere");

            migrationBuilder.DropColumn(
                name: "CityCrawlID",
                table: "virksomheder");

            migrationBuilder.DropColumn(
                name: "CityCrawlID",
                table: "brugere");
        }
    }
}
