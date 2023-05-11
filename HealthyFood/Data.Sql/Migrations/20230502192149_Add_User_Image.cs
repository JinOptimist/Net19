using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_Image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageUploaderId",
                table: "WikiMcImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WikiMcImages_ImageUploaderId",
                table: "WikiMcImages",
                column: "ImageUploaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiMcImages_Users_ImageUploaderId",
                table: "WikiMcImages",
                column: "ImageUploaderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WikiMcImages_Users_ImageUploaderId",
                table: "WikiMcImages");

            migrationBuilder.DropIndex(
                name: "IX_WikiMcImages_ImageUploaderId",
                table: "WikiMcImages");

            migrationBuilder.DropColumn(
                name: "ImageUploaderId",
                table: "WikiMcImages");
        }
    }
}
