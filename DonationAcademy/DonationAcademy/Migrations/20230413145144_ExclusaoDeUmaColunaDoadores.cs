using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class ExclusaoDeUmaColunaDoadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doadores_Material_MaterialId",
                table: "Doadores");

            migrationBuilder.DropIndex(
                name: "IX_Doadores_MaterialId",
                table: "Doadores");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Doadores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Doadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doadores_MaterialId",
                table: "Doadores",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doadores_Material_MaterialId",
                table: "Doadores",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
