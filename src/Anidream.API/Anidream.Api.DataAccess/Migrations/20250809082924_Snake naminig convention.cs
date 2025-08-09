using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anidream.Api.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Snakenaminigconvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Directors_DirectorId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Studios_StudioId",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studios",
                table: "Studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Studios",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "StudioId",
                table: "Studios",
                newName: "studio_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Medias",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Medias",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Medias",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Alias",
                table: "Medias",
                newName: "alias");

            migrationBuilder.RenameColumn(
                name: "TotalEpisodes",
                table: "Medias",
                newName: "total_episodes");

            migrationBuilder.RenameColumn(
                name: "StudioId",
                table: "Medias",
                newName: "studio_id");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Medias",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "Medias",
                newName: "director_id");

            migrationBuilder.RenameColumn(
                name: "CurrentEpisodes",
                table: "Medias",
                newName: "current_episodes");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Medias",
                newName: "media_id");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_StudioId",
                table: "Medias",
                newName: "ix_medias_studio_id");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_DirectorId",
                table: "Medias",
                newName: "ix_medias_director_id");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Directors",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "Directors",
                newName: "director_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_studios",
                table: "Studios",
                column: "studio_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_medias",
                table: "Medias",
                column: "media_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_directors",
                table: "Directors",
                column: "director_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_medias_director_director_id",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "fk_medias_studio_studio_id",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "pk_studios",
                table: "Studios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_medias",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "pk_directors",
                table: "Directors");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Studios",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "studio_id",
                table: "Studios",
                newName: "StudioId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Medias",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Medias",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Medias",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "alias",
                table: "Medias",
                newName: "Alias");

            migrationBuilder.RenameColumn(
                name: "total_episodes",
                table: "Medias",
                newName: "TotalEpisodes");

            migrationBuilder.RenameColumn(
                name: "studio_id",
                table: "Medias",
                newName: "StudioId");

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "Medias",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "director_id",
                table: "Medias",
                newName: "DirectorId");

            migrationBuilder.RenameColumn(
                name: "current_episodes",
                table: "Medias",
                newName: "CurrentEpisodes");

            migrationBuilder.RenameColumn(
                name: "media_id",
                table: "Medias",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "ix_medias_studio_id",
                table: "Medias",
                newName: "IX_Medias_StudioId");

            migrationBuilder.RenameIndex(
                name: "ix_medias_director_id",
                table: "Medias",
                newName: "IX_Medias_DirectorId");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Directors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "director_id",
                table: "Directors",
                newName: "DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studios",
                table: "Studios",
                column: "StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "DirectorId");

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
    }
}
