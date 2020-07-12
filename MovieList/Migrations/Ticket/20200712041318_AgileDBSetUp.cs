using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieList.Migrations.Ticket
{
    public partial class AgileDBSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Tickets");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    Sprint = table.Column<int>(nullable: false),
                    Point = table.Column<int>(nullable: false),
                    StatusId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { "todo", "To Do" },
                    { "inprogress", "In Progress" },
                    { "qa", "Quality Assurance" },
                    { "done", "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Description", "Point", "Sprint", "StatusId", "TicketName" },
                values: new object[] { 1, "Set up Index Page", 2, 1, "todo", "Agile Index" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
