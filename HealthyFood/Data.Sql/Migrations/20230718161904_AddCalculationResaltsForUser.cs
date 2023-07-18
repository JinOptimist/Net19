using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class AddCalculationResaltsForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WikiCalculationResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageCalculatedCalories = table.Column<int>(type: "int", nullable: false),
                    GramsProtein = table.Column<int>(type: "int", nullable: false),
                    GramsFat = table.Column<int>(type: "int", nullable: false),
                    GramsCarb = table.Column<int>(type: "int", nullable: false),
                    CalculatorUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiCalculationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WikiCalculationResults_Users_CalculatorUserId",
                        column: x => x.CalculatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WikiCalculationResults_CalculatorUserId",
                table: "WikiCalculationResults",
                column: "CalculatorUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WikiCalculationResults");
        }
    }
}
