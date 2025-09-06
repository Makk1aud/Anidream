using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anidream.Api.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddattributerIsDeletedHasImagetoMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "has_image",
                table: "Medias",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Medias",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "has_image",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Medias");
        }
    }
}
