using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmDB.Migrations
{
    public partial class GenreTableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_GenreModel_GenreId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreModel",
                table: "GenreModel");

            migrationBuilder.RenameTable(
                name: "GenreModel",
                newName: "Genre");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Films",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Genre_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Genre_GenreId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "GenreModel");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreModel",
                table: "GenreModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_GenreModel_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "GenreModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
