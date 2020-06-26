using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieList.Migrations.Country
{
    public partial class InitialOlympicGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SportTypes",
                columns: table => new
                {
                    SportTypeID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTypes", x => x.SportTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Countrys",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SportTypeID = table.Column<string>(nullable: true),
                    Sport = table.Column<string>(nullable: true),
                    CategoryID = table.Column<string>(nullable: true),
                    LogoImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countrys_Categorys_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categorys",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countrys_SportTypes_SportTypeID",
                        column: x => x.SportTypeID,
                        principalTable: "SportTypes",
                        principalColumn: "SportTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { "in", "Indoor" },
                    { "out", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "SportTypes",
                columns: new[] { "SportTypeID", "Name" },
                values: new object[,]
                {
                    { "sum", "Summer Olympics" },
                    { "win", "Winter Olympics" },
                    { "par", "Paralympic Games" },
                    { "you", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "CountryID", "CategoryID", "LogoImage", "Name", "Sport", "SportTypeID" },
                values: new object[,]
                {
                    { "ger", "in", "GER.png", "Germany", "Diving", "sum" },
                    { "fin", "out", "FIN.png", "Finland", "Skateboarding", "you" },
                    { "rus", "in", "RUS.png", "Russia", "Breakdancing", "you" },
                    { "cyp", "in", "CYP.png", "Cyprus", "Breakdancing", "you" },
                    { "fra", "in", "FRA.png", "France", "Breakdancing", "you" },
                    { "zim", "out", "ZIM.png", "Zimbabwe", "Canoe Sprint", "par" },
                    { "pak", "out", "PAK.png", "Pakistan", "Canoe Sprint", "par" },
                    { "aus", "out", "AUS.png", "Austria", "Canoe Sprint", "par" },
                    { "ukr", "in", "UKR.png", "Ukraine", "Archery", "par" },
                    { "uru", "in", "URU.png", "Uruguay", "Archery", "par" },
                    { "tha", "in", "THA.png", "Thailan", "Archery", "par" },
                    { "jap", "out", "JAP.png", "Japan", "Bobsleigh", "win" },
                    { "ita", "out", "ITA.png", "Italy", "Bobsleigh", "win" },
                    { "jam", "out", "JAM.png", "Jamaica", "Bobsleigh", "win" },
                    { "grb", "in", "GRB.png", "Great Britain", "Curling", "win" },
                    { "swe", "in", "SWE.png", "Sweden", "Curling", "win" },
                    { "can", "in", "CAN.png", "Canada", "Curling", "win" },
                    { "usa", "out", "USA.png", "USA", "Road Cycling", "sum" },
                    { "net", "out", "NET.png", "Netherlands", "Road Cycling", "sum" },
                    { "bra", "out", "BRA.png", "Brazil", "Road Cycling", "sum" },
                    { "mex", "in", "MEX.png", "Mexico", "Diving", "sum" },
                    { "chi", "in", "CHI.png", "China", "Diving", "sum" },
                    { "slo", "out", "SLO.png", "Slovakia", "Skateboarding", "you" },
                    { "por", "out", "POR.png", "Portugal", "Skateboarding", "you" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countrys_CategoryID",
                table: "Countrys",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countrys_SportTypeID",
                table: "Countrys",
                column: "SportTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countrys");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "SportTypes");
        }
    }
}
