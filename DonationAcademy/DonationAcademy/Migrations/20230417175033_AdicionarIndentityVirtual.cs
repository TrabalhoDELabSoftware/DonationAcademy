using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarIndentityVirtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Doadores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doadores_UserId",
                table: "Doadores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doadores_AspNetUsers_UserId",
                table: "Doadores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doadores_AspNetUsers_UserId",
                table: "Doadores");

            migrationBuilder.DropIndex(
                name: "IX_Doadores_UserId",
                table: "Doadores");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Doadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
