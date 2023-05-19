using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarColunaPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMaterialPago",
                table: "Material",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMaterialPago",
                table: "Material");
        }
    }
}
