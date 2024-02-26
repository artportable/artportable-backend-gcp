using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class userExhibitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_artworks_files_primary_file_id",
                table: "artworks");

            migrationBuilder.DropIndex(
                name: "ix_artworks_primary_file_id",
                table: "artworks");

            migrationBuilder.AddColumn<bool>(
                name: "exhibition",
                table: "stories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "primary_file_id",
                table: "artworks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "ix_artworks_primary_file_id",
                table: "artworks",
                column: "primary_file_id",
                unique: true,
                filter: "[primary_file_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_artworks_files_primary_file_id",
                table: "artworks",
                column: "primary_file_id",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_artworks_files_primary_file_id",
                table: "artworks");

            migrationBuilder.DropIndex(
                name: "ix_artworks_primary_file_id",
                table: "artworks");

            migrationBuilder.DropColumn(
                name: "exhibition",
                table: "stories");

            migrationBuilder.AlterColumn<int>(
                name: "primary_file_id",
                table: "artworks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_artworks_primary_file_id",
                table: "artworks",
                column: "primary_file_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_artworks_files_primary_file_id",
                table: "artworks",
                column: "primary_file_id",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
