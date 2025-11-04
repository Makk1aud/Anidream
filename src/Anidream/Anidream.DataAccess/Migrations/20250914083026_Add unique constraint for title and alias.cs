using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anidream.Api.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Adduniqueconstraintfortitleandalias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_studios_title",
                table: "Studios",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_medias_alias",
                table: "Medias",
                column: "alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_medias_title",
                table: "Medias",
                column: "title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_studios_title",
                table: "Studios");

            migrationBuilder.DropIndex(
                name: "ix_medias_alias",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "ix_medias_title",
                table: "Medias");
        }
    }
}
