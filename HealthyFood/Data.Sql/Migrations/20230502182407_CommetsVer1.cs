using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class CommetsVer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WikiBlockComments_PageWikiBlocks_BlockId",
                table: "WikiBlockComments");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiBlockComments_PageWikiBlocks_BlockId",
                table: "WikiBlockComments",
                column: "BlockId",
                principalTable: "PageWikiBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WikiBlockComments_PageWikiBlocks_BlockId",
                table: "WikiBlockComments");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiBlockComments_PageWikiBlocks_BlockId",
                table: "WikiBlockComments",
                column: "BlockId",
                principalTable: "PageWikiBlocks",
                principalColumn: "Id");
        }
    }
}
