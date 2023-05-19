using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class PopularMateriais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Material(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, EmEstoque, IsMaterialPago) VALUES(3, 'Livro de história', 'Livro para estudar história', 'História é bom', 0.00, 'https://cf.shopee.com.br/file/ef012dbdb50ba0fe12b815ccca3223e3', 'https://cf.shopee.com.br/file/ef012dbdb50ba0fe12b815ccca3223e3', 0, 1)");

            migrationBuilder.Sql("INSERT INTO Material(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, EmEstoque, IsMaterialPago) VALUES(4, 'Caderno de matemática', 'Caderno para estudar matemática', 'Matemática é legal', 0.00, 'https://cf.shopee.com.br/file/ef012dbdb50ba0fe12b815ccca3223e3', 'https://cf.shopee.com.br/file/ef012dbdb50ba0fe12b815ccca3223e3', 0, 1)");

            migrationBuilder.Sql("INSERT INTO Material(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, EmEstoque, IsMaterialPago) VALUES(3, 'Livro de geografia', 'Livro para estudar geografia', 'Geografia é interessante', 0.00, 'https://cf.shopee.com.br/file/ef012dbdb50ba0fe12b815ccca3223e3', 'https://cf.shopee.com.br/file/ef012dbdb50ba0fe12b815ccca3223e3', 0, 1)");

            migrationBuilder.Sql("INSERT INTO Material(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, EmEstoque, IsMaterialPago) VALUES(4, 'Caderno de história', 'Caderno para estudar história', 'História é legal', 0.00, 'https://cf.shopee.com.br/file/ef012dbdb50ba0fe12b815ccca3223e3', 'https://cf.shopee.com.br/file/ef012dbdb50ba0fe12b815ccca3223e3', 0, 1)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MATERIAL");
        }
    }
}
