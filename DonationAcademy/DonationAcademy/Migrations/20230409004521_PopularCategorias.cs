using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categoria(CategoriaNome, Descricao)" +
                "VALUES('Livros', 'Livros de diversos tipos de acordo com a matéria que você precisa')");

            migrationBuilder.Sql("INSERT INTO Categoria(CategoriaNome, Descricao)" +
               "VALUES('Cadernos', 'Cadernos de diversos tipos de acordo com a quantidade de matérias que você precisa')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categoria");
        }
    }
}
