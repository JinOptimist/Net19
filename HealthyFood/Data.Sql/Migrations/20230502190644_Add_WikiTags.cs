using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class Add_WikiTags : Migration
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
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WikiMcImageWikiTags",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiMcImageWikiTags", x => new { x.ImagesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_WikiMcImageWikiTags_WikiMcImages_ImagesId",
                        column: x => x.ImagesId,
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
                name: "WikiMcImages");

            migrationBuilder.DropTable(
                name: "WikiTags");

        }
    }
}
