using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentsVer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WikiBlockComments_Users_AuthorId",
                table: "WikiBlockComments");

            migrationBuilder.AddColumn<int>(
                name: "BlockId",
                table: "WikiBlockComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WikiBlockComments_BlockId",
                table: "WikiBlockComments",
                column: "BlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiBlockComments_PageWikiBlocks_BlockId",
                table: "WikiBlockComments",
                column: "BlockId",
                principalTable: "PageWikiBlocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiBlockComments_Users_AuthorId",
                table: "WikiBlockComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WikiBlockComments_PageWikiBlocks_BlockId",
                table: "WikiBlockComments");

            migrationBuilder.DropForeignKey(
                name: "FK_WikiBlockComments_Users_AuthorId",
                table: "WikiBlockComments");

            migrationBuilder.DropIndex(
                name: "IX_WikiBlockComments_BlockId",
                table: "WikiBlockComments");

            migrationBuilder.DropColumn(
                name: "BlockId",
                table: "WikiBlockComments");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiBlockComments_Users_AuthorId",
                table: "WikiBlockComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
