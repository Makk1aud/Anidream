using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anidream.Api.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    director_id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_directors", x => x.director_id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    studio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_studios", x => x.studio_id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    media_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    alias = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    studio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    director_id = table.Column<Guid>(type: "uuid", nullable: false),
                    release_date = table.Column<DateOnly>(type: "date", nullable: false),
                    rating = table.Column<double>(type: "double precision", nullable: false),
                    total_episodes = table.Column<int>(type: "integer", nullable: false),
                    current_episodes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medias", x => x.media_id);
                    table.ForeignKey(
                        name: "fk_medias_director_director_id",
                        column: x => x.director_id,
                        principalTable: "Directors",
                        principalColumn: "director_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_medias_studio_studio_id",
                        column: x => x.studio_id,
                        principalTable: "Studios",
                        principalColumn: "studio_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_medias_director_id",
                table: "Medias",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "ix_medias_studio_id",
                table: "Medias",
                column: "studio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
