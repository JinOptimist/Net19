using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addWikiTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WikiTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WikiMcImageWikiTags",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiMcImageWikiTags", x => new { x.ImageId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_WikiMcImageWikiTags_WikiMcImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "WikiMcImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WikiMcImageWikiTags_WikiTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "WikiTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WikiMcImageWikiTags_TagsId",
                table: "WikiMcImageWikiTags",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WikiMcImageWikiTags");

            migrationBuilder.DropTable(
                name: "WikiTags");
        }
    }
}
