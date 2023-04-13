using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addconnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizPlayerId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_QuizPlayerId",
                table: "Users",
                column: "QuizPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_QuizPlayers_QuizPlayerId",
                table: "Users",
                column: "QuizPlayerId",
                principalTable: "QuizPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_QuizPlayers_QuizPlayerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_QuizPlayerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "QuizPlayerId",
                table: "Users");
        }
    }
}
