using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCategoriaDoadorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaDoadorId",
                table: "Doadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoriaDoadores",
                columns: table => new
                {
                    CategoriaDoadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaDoadorNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaDoadores", x => x.CategoriaDoadorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doadores_CategoriaDoadorId",
                table: "Doadores",
                column: "CategoriaDoadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doadores_CategoriaDoadores_CategoriaDoadorId",
                table: "Doadores",
                column: "CategoriaDoadorId",
                principalTable: "CategoriaDoadores",
                principalColumn: "CategoriaDoadorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doadores_CategoriaDoadores_CategoriaDoadorId",
                table: "Doadores");

            migrationBuilder.DropTable(
                name: "CategoriaDoadores");

            migrationBuilder.DropIndex(
                name: "IX_Doadores_CategoriaDoadorId",
                table: "Doadores");

            migrationBuilder.DropColumn(
                name: "CategoriaDoadorId",
                table: "Doadores");
        }
    }
}
