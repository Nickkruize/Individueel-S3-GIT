using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDBCore.Migrations
{
    public partial class UpdateArtistGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ArtistGenres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ArtistGenres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
