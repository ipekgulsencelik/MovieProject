using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_edit_base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Films_FilmID",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "FilmID",
                table: "Reviews",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_FilmID",
                table: "Reviews",
                newName: "IX_Reviews_FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Films_FilmId",
                table: "Reviews",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Films_FilmId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Reviews",
                newName: "FilmID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_FilmId",
                table: "Reviews",
                newName: "IX_Reviews_FilmID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Films_FilmID",
                table: "Reviews",
                column: "FilmID",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
