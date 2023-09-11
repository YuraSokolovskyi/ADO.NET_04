using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkHW.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Draws", "Losses", "Name", "Position", "Wins" },
                values: new object[,]
                {
                    { 1, 8, 9, "Spain", 1, 10 },
                    { 2, 8, 10, "Norway", 2, 9 },
                    { 3, 9, 10, "France", 3, 8 },
                    { 4, 9, 12, "Germany", 4, 6 },
                    { 5, 10, 13, "Austria", 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
