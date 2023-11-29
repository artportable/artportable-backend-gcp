using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class StoriesRemoveTextColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "stories",
                type: "nvarchar(max)",
                maxLength: 8192,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "stories",
                type: "Text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8192,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "Text", nullable: true),
                    primary_file_id = table.Column<int>(type: "int", nullable: false),
                    public_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    published = table.Column<DateTime>(type: "datetime2", nullable: false),
                    secondary_file_id = table.Column<int>(type: "int", nullable: true),
                    tertiary_file_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tests", x => x.id);
                    table.ForeignKey(
                        name: "fk_tests_files_primary_file_id",
                        column: x => x.primary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tests_files_secondary_file_id",
                        column: x => x.secondary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tests_files_tertiary_file_id",
                        column: x => x.tertiary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tests_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tests_primary_file_id",
                table: "tests",
                column: "primary_file_id");

            migrationBuilder.CreateIndex(
                name: "ix_tests_public_id",
                table: "tests",
                column: "public_id");

            migrationBuilder.CreateIndex(
                name: "ix_tests_secondary_file_id",
                table: "tests",
                column: "secondary_file_id");

            migrationBuilder.CreateIndex(
                name: "ix_tests_tertiary_file_id",
                table: "tests",
                column: "tertiary_file_id");

            migrationBuilder.CreateIndex(
                name: "ix_tests_user_id",
                table: "tests",
                column: "user_id");
        }
    }
}
