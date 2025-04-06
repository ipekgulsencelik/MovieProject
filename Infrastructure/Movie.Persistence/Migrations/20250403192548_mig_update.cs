using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilm_Categories_CategoriesCategoryID",
                table: "CategoryFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilm_Films_FilmsFilmID",
                table: "CategoryFilm");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "TagID",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Reviews",
                newName: "ReviewDate");

            migrationBuilder.RenameColumn(
                name: "ReviewID",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FilmID",
                table: "Films",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FilmsFilmID",
                table: "CategoryFilm",
                newName: "FilmsId");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryID",
                table: "CategoryFilm",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryFilm_FilmsFilmID",
                table: "CategoryFilm",
                newName: "IX_CategoryFilm_FilmsId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CastID",
                table: "Casts",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Reviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Reviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewStatus",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Films",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Films",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Films",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieStatus",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Casts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "Casts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Casts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Casts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilm_Categories_CategoriesId",
                table: "CategoryFilm",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilm_Films_FilmsId",
                table: "CategoryFilm",
                column: "FilmsId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilm_Categories_CategoriesId",
                table: "CategoryFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilm_Films_FilmsId",
                table: "CategoryFilm");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewStatus",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "MovieStatus",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Casts");

            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "Casts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Casts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Casts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "TagID");

            migrationBuilder.RenameColumn(
                name: "ReviewDate",
                table: "Reviews",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "ReviewID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Films",
                newName: "FilmID");

            migrationBuilder.RenameColumn(
                name: "FilmsId",
                table: "CategoryFilm",
                newName: "FilmsFilmID");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CategoryFilm",
                newName: "CategoriesCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryFilm_FilmsId",
                table: "CategoryFilm",
                newName: "IX_CategoryFilm_FilmsFilmID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Casts",
                newName: "CastID");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilm_Categories_CategoriesCategoryID",
                table: "CategoryFilm",
                column: "CategoriesCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilm_Films_FilmsFilmID",
                table: "CategoryFilm",
                column: "FilmsFilmID",
                principalTable: "Films",
                principalColumn: "FilmID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
