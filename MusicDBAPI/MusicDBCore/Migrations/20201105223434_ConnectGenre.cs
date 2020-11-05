using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDBCore.Migrations
{
    public partial class ConnectGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Genres_GenreId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_GenreId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Artist");

            migrationBuilder.CreateTable(
                name: "ArtistGenres",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGenres", x => new { x.ArtistId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ArtistGenres_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenres_GenreId",
                table: "ArtistGenres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistGenres");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Artist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_GenreId",
                table: "Artist",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Genres_GenreId",
                table: "Artist",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
