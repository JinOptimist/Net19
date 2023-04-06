using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class Addconnetiongamesusersrename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameUser_Users_UsersId",
                table: "GameUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "GameUser",
                newName: "PlayersId");

            migrationBuilder.RenameIndex(
                name: "IX_GameUser_UsersId",
                table: "GameUser",
                newName: "IX_GameUser_PlayersId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameUser_Users_PlayersId",
                table: "GameUser",
                column: "PlayersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameUser_Users_PlayersId",
                table: "GameUser");

            migrationBuilder.RenameColumn(
                name: "PlayersId",
                table: "GameUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_GameUser_PlayersId",
                table: "GameUser",
                newName: "IX_GameUser_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameUser_Users_UsersId",
                table: "GameUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
