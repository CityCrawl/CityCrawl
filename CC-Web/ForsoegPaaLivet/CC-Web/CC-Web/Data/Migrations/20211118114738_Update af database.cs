using Microsoft.EntityFrameworkCore.Migrations;

namespace CC_Web.Data.Migrations
{
    public partial class Updateafdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brugere_cityCrawls_CityCrawlId",
                table: "brugere");

            migrationBuilder.DropForeignKey(
                name: "FK_virksomheder_cityCrawls_CityCrawlID",
                table: "virksomheder");

            migrationBuilder.DropIndex(
                name: "IX_brugere_CityCrawlId",
                table: "brugere");

            migrationBuilder.DropColumn(
                name: "Begivenhed",
                table: "cityCrawls");

            migrationBuilder.DropColumn(
                name: "Dato",
                table: "cityCrawls");

            migrationBuilder.DropColumn(
                name: "Sted",
                table: "cityCrawls");

            migrationBuilder.RenameColumn(
                name: "CityCrawlID",
                table: "virksomheder",
                newName: "CityCrawlId");

            migrationBuilder.RenameIndex(
                name: "IX_virksomheder_CityCrawlID",
                table: "virksomheder",
                newName: "IX_virksomheder_CityCrawlId");

            migrationBuilder.RenameColumn(
                name: "CityCrawlId",
                table: "brugere",
                newName: "BookdPubcrawlsId");

            migrationBuilder.AlterColumn<int>(
                name: "CityCrawlId",
                table: "virksomheder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookedPubcrawlsId",
                table: "brugere",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookedPubcrawls",
                columns: table => new
                {
                    BookedPubcrawlsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityCrawlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedPubcrawls", x => x.BookedPubcrawlsId);
                    table.ForeignKey(
                        name: "FK_BookedPubcrawls_cityCrawls_CityCrawlId",
                        column: x => x.CityCrawlId,
                        principalTable: "cityCrawls",
                        principalColumn: "CityCrawlID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brugere_BookedPubcrawlsId",
                table: "brugere",
                column: "BookedPubcrawlsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedPubcrawls_CityCrawlId",
                table: "BookedPubcrawls",
                column: "CityCrawlId");

            migrationBuilder.AddForeignKey(
                name: "FK_brugere_BookedPubcrawls_BookedPubcrawlsId",
                table: "brugere",
                column: "BookedPubcrawlsId",
                principalTable: "BookedPubcrawls",
                principalColumn: "BookedPubcrawlsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_virksomheder_cityCrawls_CityCrawlId",
                table: "virksomheder",
                column: "CityCrawlId",
                principalTable: "cityCrawls",
                principalColumn: "CityCrawlID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brugere_BookedPubcrawls_BookedPubcrawlsId",
                table: "brugere");

            migrationBuilder.DropForeignKey(
                name: "FK_virksomheder_cityCrawls_CityCrawlId",
                table: "virksomheder");

            migrationBuilder.DropTable(
                name: "BookedPubcrawls");

            migrationBuilder.DropIndex(
                name: "IX_brugere_BookedPubcrawlsId",
                table: "brugere");

            migrationBuilder.DropColumn(
                name: "BookedPubcrawlsId",
                table: "brugere");

            migrationBuilder.RenameColumn(
                name: "CityCrawlId",
                table: "virksomheder",
                newName: "CityCrawlID");

            migrationBuilder.RenameIndex(
                name: "IX_virksomheder_CityCrawlId",
                table: "virksomheder",
                newName: "IX_virksomheder_CityCrawlID");

            migrationBuilder.RenameColumn(
                name: "BookdPubcrawlsId",
                table: "brugere",
                newName: "CityCrawlId");

            migrationBuilder.AlterColumn<int>(
                name: "CityCrawlID",
                table: "virksomheder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Begivenhed",
                table: "cityCrawls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dato",
                table: "cityCrawls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sted",
                table: "cityCrawls",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
