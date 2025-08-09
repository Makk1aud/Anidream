using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anidream.Api.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddentitiesDirectorStudioUpdateentityMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medias");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Medias",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Medias",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentEpisodes",
                table: "Medias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DirectorId",
                table: "Medias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Medias",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0
                );

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReleaseDate",
                table: "Medias",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<Guid>(
                name: "StudioId",
                table: "Medias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TotalEpisodes",
                table: "Medias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "MediaId");

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorId = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_DirectorId",
                table: "Medias",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_StudioId",
                table: "Medias",
                column: "StudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Directors_DirectorId",
                table: "Medias",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Studios_StudioId",
                table: "Medias",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "StudioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Directors_DirectorId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Studios_StudioId",
                table: "Medias");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_DirectorId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_StudioId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "CurrentEpisodes",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TotalEpisodes",
                table: "Medias");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Media");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Media",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "MediaId");
        }
    }
}
