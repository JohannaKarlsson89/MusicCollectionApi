using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicCollectionApi.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_ALbumId",
                table: "Song");

            migrationBuilder.RenameColumn(
                name: "ALbumId",
                table: "Song",
                newName: "AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_ALbumId",
                table: "Song",
                newName: "IX_Song_AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Song",
                newName: "ALbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_AlbumId",
                table: "Song",
                newName: "IX_Song_ALbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_ALbumId",
                table: "Song",
                column: "ALbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
