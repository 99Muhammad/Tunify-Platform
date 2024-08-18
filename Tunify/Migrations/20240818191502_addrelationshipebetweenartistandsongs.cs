using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify.Migrations
{
    /// <inheritdoc />
    public partial class addrelationshipebetweenartistandsongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayListSong_PlayList_PlayListID",
                table: "PlayListSong");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayListSong_Songs_SongID",
                table: "PlayListSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayListSong",
                table: "PlayListSong");

            migrationBuilder.RenameTable(
                name: "PlayListSong",
                newName: "PlayListSongs");

            migrationBuilder.RenameIndex(
                name: "IX_PlayListSong_SongID",
                table: "PlayListSongs",
                newName: "IX_PlayListSongs_SongID");

            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayListSongs",
                table: "PlayListSongs",
                columns: new[] { "PlayListID", "SongID" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistsID", "ArtistName", "Bio" },
                values: new object[,]
                {
                    { 1, "Michael Jackson", " good" },
                    { 2, "Pink Floyd", " good" },
                    { 3, "The Beatles", " good" }
                });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongID",
                keyValue: 1,
                column: "ArtistID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongID",
                keyValue: 2,
                column: "ArtistID",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistID",
                table: "Songs",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListSongs_PlayList_PlayListID",
                table: "PlayListSongs",
                column: "PlayListID",
                principalTable: "PlayList",
                principalColumn: "PlayListID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListSongs_Songs_SongID",
                table: "PlayListSongs",
                column: "SongID",
                principalTable: "Songs",
                principalColumn: "SongID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ArtistsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayListSongs_PlayList_PlayListID",
                table: "PlayListSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayListSongs_Songs_SongID",
                table: "PlayListSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistID",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayListSongs",
                table: "PlayListSongs");

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "PlayListSongs",
                newName: "PlayListSong");

            migrationBuilder.RenameIndex(
                name: "IX_PlayListSongs_SongID",
                table: "PlayListSong",
                newName: "IX_PlayListSong_SongID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayListSong",
                table: "PlayListSong",
                columns: new[] { "PlayListID", "SongID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListSong_PlayList_PlayListID",
                table: "PlayListSong",
                column: "PlayListID",
                principalTable: "PlayList",
                principalColumn: "PlayListID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListSong_Songs_SongID",
                table: "PlayListSong",
                column: "SongID",
                principalTable: "Songs",
                principalColumn: "SongID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
