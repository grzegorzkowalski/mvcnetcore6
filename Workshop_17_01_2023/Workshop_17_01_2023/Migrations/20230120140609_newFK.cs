using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmDB.Migrations
{
    public partial class newFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Films_Genres_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
