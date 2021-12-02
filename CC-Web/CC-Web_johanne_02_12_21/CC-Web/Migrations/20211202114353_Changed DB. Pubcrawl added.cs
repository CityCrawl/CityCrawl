using Microsoft.EntityFrameworkCore.Migrations;

namespace CC_Web.Migrations
{
    public partial class ChangedDBPubcrawladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cityCrawls");

            migrationBuilder.CreateTable(
                name: "pubcrawls",
                columns: table => new
                {
                    PubcrawlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PakkeNavn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pubcrawls", x => x.PubcrawlId);
                });

            migrationBuilder.CreateTable(
                name: "BrugerPubcrawl",
                columns: table => new
                {
                    BrugereBrugerID = table.Column<int>(type: "int", nullable: false),
                    PubcrawlsPubcrawlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrugerPubcrawl", x => new { x.BrugereBrugerID, x.PubcrawlsPubcrawlId });
                    table.ForeignKey(
                        name: "FK_BrugerPubcrawl_brugere_BrugereBrugerID",
                        column: x => x.BrugereBrugerID,
                        principalTable: "brugere",
                        principalColumn: "BrugerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrugerPubcrawl_pubcrawls_PubcrawlsPubcrawlId",
                        column: x => x.PubcrawlsPubcrawlId,
                        principalTable: "pubcrawls",
                        principalColumn: "PubcrawlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PubcrawlVirksomhed",
                columns: table => new
                {
                    PubcrawlsPubcrawlId = table.Column<int>(type: "int", nullable: false),
                    VirksomhederVirksomhedID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubcrawlVirksomhed", x => new { x.PubcrawlsPubcrawlId, x.VirksomhederVirksomhedID });
                    table.ForeignKey(
                        name: "FK_PubcrawlVirksomhed_pubcrawls_PubcrawlsPubcrawlId",
                        column: x => x.PubcrawlsPubcrawlId,
                        principalTable: "pubcrawls",
                        principalColumn: "PubcrawlId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubcrawlVirksomhed_virksomheder_VirksomhederVirksomhedID",
                        column: x => x.VirksomhederVirksomhedID,
                        principalTable: "virksomheder",
                        principalColumn: "VirksomhedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrugerPubcrawl_PubcrawlsPubcrawlId",
                table: "BrugerPubcrawl",
                column: "PubcrawlsPubcrawlId");

            migrationBuilder.CreateIndex(
                name: "IX_PubcrawlVirksomhed_VirksomhederVirksomhedID",
                table: "PubcrawlVirksomhed",
                column: "VirksomhederVirksomhedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrugerPubcrawl");

            migrationBuilder.DropTable(
                name: "PubcrawlVirksomhed");

            migrationBuilder.DropTable(
                name: "pubcrawls");

            migrationBuilder.CreateTable(
                name: "cityCrawls",
                columns: table => new
                {
                    CityCrawlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begivenhed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrugerID = table.Column<int>(type: "int", nullable: true),
                    Dato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityCrawls", x => x.CityCrawlID);
                    table.ForeignKey(
                        name: "FK_cityCrawls_brugere_BrugerID",
                        column: x => x.BrugerID,
                        principalTable: "brugere",
                        principalColumn: "BrugerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cityCrawls_BrugerID",
                table: "cityCrawls",
                column: "BrugerID");
        }
    }
}
