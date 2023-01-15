using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiVideoGamesExcercise.Migrations
{
    public partial class InitialMigration_After_Scaffolding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //create table are manually deleted b/c scaffolding was used to manage those

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "Name", "Price", "Size", "VideoGameStudioId" },
                values: new object[,]
                {
                    { 1, "Counter Strike", 50m, 2000, 1 },
                    { 2, "Pro Evolution", 55m, 2100, 1 },
                    { 3, "FIFA", 60m, 2200, 1 },
                    { 4, "Call of Duty", 65m, 2300, 1 },
                    { 5, "Blur", 70m, 2400, 1 },
                    { 6, "Assasin Creed", 75m, 2500, 1 }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGames");

            migrationBuilder.DropTable(
                name: "VideoGameStudio");
        }
    }
}
