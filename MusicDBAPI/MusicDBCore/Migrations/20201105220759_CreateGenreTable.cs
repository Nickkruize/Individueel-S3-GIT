using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDBCore.Migrations
{
    public partial class CreateGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Artist",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Genres_GenreId",
                table: "Artist");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Artist_GenreId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Artist");
        }
    }
}
