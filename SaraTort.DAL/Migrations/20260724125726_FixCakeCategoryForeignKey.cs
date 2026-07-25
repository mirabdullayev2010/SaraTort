using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaraTort.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixCakeCategoryForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cakes_Categories_CategoryId1",
                table: "Cakes");

            migrationBuilder.DropIndex(
                name: "IX_Cakes_CategoryId1",
                table: "Cakes");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Cakes");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "Cakes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_category_id",
                table: "Cakes",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cakes_Categories_category_id",
                table: "Cakes",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cakes_Categories_category_id",
                table: "Cakes");

            migrationBuilder.DropIndex(
                name: "IX_Cakes_category_id",
                table: "Cakes");

            migrationBuilder.AlterColumn<long>(
                name: "category_id",
                table: "Cakes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Cakes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_CategoryId1",
                table: "Cakes",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cakes_Categories_CategoryId1",
                table: "Cakes",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
