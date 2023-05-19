using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarNomeCompletoEmDoadorM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCompleto",
                table: "Doadores",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdminRegistroUsuarioViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailRegister = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVendedor = table.Column<bool>(type: "bit", nullable: false),
                    IsGerente = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsDoador = table.Column<bool>(type: "bit", nullable: false),
                    GeneratedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRegistroUsuarioViewModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRegistroUsuarioViewModel");

            migrationBuilder.DropColumn(
                name: "NomeCompleto",
                table: "Doadores");
        }
    }
}
