using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BanAdmin.Migrations
{
    public partial class AddedBans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ban",
                columns: table => new
                {
                    ID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    DescriptionOfPerson = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    BanStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BanEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BanType = table.Column<byte>(type: "INTEGER", nullable: false),
                    CustomBanDescription = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ban", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ban");
        }
    }
}
