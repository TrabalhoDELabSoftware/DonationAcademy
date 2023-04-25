using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class ExcluirCategoriaIdDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doadores_Categoria_CategoriaId",
                table: "Doadores");

            migrationBuilder.DropIndex(
                name: "IX_Doadores_CategoriaId",
                table: "Doadores");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Doadores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Doadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doadores_CategoriaId",
                table: "Doadores",
                column: "CategoriaId");

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
