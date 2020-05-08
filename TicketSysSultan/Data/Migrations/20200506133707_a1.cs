using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSysSultan.Data.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ExtNum = table.Column<string>(nullable: true),
                    Issue = table.Column<string>(nullable: true),
                    Solution = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false), 
                    CloseDateTime = table.Column<DateTime>(nullable: true),
                    Closed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
