using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CC_Web.Migrations
{
    public partial class BrugerDtoaddedTOusetokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "brugere",
                newName: "PwHash");

            migrationBuilder.RenameColumn(
                name: "Foravn",
                table: "brugere",
                newName: "Fornavn");

            migrationBuilder.AddColumn<string>(
                name: "MoedeSted",
                table: "pubcrawls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MoedeTid",
                table: "pubcrawls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoedeSted",
                table: "pubcrawls");

            migrationBuilder.DropColumn(
                name: "MoedeTid",
                table: "pubcrawls");

            migrationBuilder.RenameColumn(
                name: "PwHash",
                table: "brugere",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Fornavn",
                table: "brugere",
                newName: "Foravn");
        }
    }
}
