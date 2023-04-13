using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addParametr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RightAnswer",
                table: "QuizQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RightAnswer",
                table: "QuizQuestions");
        }
    }
}
