using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSysSultan.Data.Migrations
{
    public partial class members : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Ticket",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_MemberId",
                table: "Ticket",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Member_MemberId",
                table: "Ticket",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Member_MemberId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_MemberId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Ticket");
        }
    }
}
