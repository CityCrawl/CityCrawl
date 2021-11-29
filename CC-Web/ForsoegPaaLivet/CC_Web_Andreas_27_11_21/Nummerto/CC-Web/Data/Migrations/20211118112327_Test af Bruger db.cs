using Microsoft.EntityFrameworkCore.Migrations;

namespace CC_Web.Data.Migrations
{
    public partial class TestafBrugerdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityCrawlID",
                table: "virksomheder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityCrawlId",
                table: "brugere",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_virksomheder_CityCrawlID",
                table: "virksomheder",
                column: "CityCrawlID");

            migrationBuilder.CreateIndex(
                name: "IX_brugere_CityCrawlId",
                table: "brugere",
                column: "CityCrawlId");

            migrationBuilder.AddForeignKey(
                name: "FK_brugere_cityCrawls_CityCrawlId",
                table: "brugere",
                column: "CityCrawlId",
                principalTable: "cityCrawls",
                principalColumn: "CityCrawlID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_virksomheder_cityCrawls_CityCrawlID",
                table: "virksomheder",
                column: "CityCrawlID",
                principalTable: "cityCrawls",
                principalColumn: "CityCrawlID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brugere_cityCrawls_CityCrawlId",
                table: "brugere");

            migrationBuilder.DropForeignKey(
                name: "FK_virksomheder_cityCrawls_CityCrawlID",
                table: "virksomheder");

            migrationBuilder.DropIndex(
                name: "IX_virksomheder_CityCrawlID",
                table: "virksomheder");

            migrationBuilder.DropIndex(
                name: "IX_brugere_CityCrawlId",
                table: "brugere");

            migrationBuilder.DropColumn(
                name: "CityCrawlID",
                table: "virksomheder");

            migrationBuilder.DropColumn(
                name: "CityCrawlId",
                table: "brugere");
        }
    }
}
