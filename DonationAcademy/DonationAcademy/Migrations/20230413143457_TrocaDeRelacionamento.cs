using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class TrocaDeRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doadores_Categoria_CategoriaId",
                table: "Doadores");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Doadores",
                newName: "MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Doadores_CategoriaId",
                table: "Doadores",
                newName: "IX_Doadores_MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doadores_Material_MaterialId",
                table: "Doadores",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doadores_Material_MaterialId",
                table: "Doadores");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "Doadores",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Doadores_MaterialId",
                table: "Doadores",
                newName: "IX_Doadores_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doadores_Categoria_CategoriaId",
                table: "Doadores",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
