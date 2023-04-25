using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Doadores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Doadores");
        }
    }
}
