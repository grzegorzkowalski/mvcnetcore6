using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmDB.Migrations
{
    public partial class GenreSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Films",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GenreModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreId",
                table: "Films",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_GenreModel_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "GenreModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_GenreModel_GenreId",
                table: "Films");

            migrationBuilder.DropTable(
                name: "GenreModel");

            migrationBuilder.DropIndex(
                name: "IX_Films_GenreId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Films");
        }
    }
}
