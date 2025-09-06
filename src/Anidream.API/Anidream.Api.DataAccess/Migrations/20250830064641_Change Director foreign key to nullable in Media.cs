using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anidream.Api.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDirectorforeignkeytonullableinMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_medias_director_director_id",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "fk_medias_studio_studio_id",
                table: "Medias");

            migrationBuilder.AlterColumn<Guid>(
                name: "studio_id",
                table: "Medias",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "director_id",
                table: "Medias",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_medias_director_director_id",
                table: "Medias",
                column: "director_id",
                principalTable: "Directors",
                principalColumn: "director_id");

            migrationBuilder.AddForeignKey(
                name: "fk_medias_studio_studio_id",
                table: "Medias",
                column: "studio_id",
                principalTable: "Studios",
                principalColumn: "studio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_medias_director_director_id",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "fk_medias_studio_studio_id",
                table: "Medias");

            migrationBuilder.AlterColumn<Guid>(
                name: "studio_id",
                table: "Medias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "director_id",
                table: "Medias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_medias_director_director_id",
                table: "Medias",
                column: "director_id",
                principalTable: "Directors",
                principalColumn: "director_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_medias_studio_studio_id",
                table: "Medias",
                column: "studio_id",
                principalTable: "Studios",
                principalColumn: "studio_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
