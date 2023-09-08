using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cagnottes_entreprises_EntrepriseId",
                table: "cagnottes");

            migrationBuilder.RenameColumn(
                name: "EntrepriseId",
                table: "cagnottes",
                newName: "EntrepriseFk");

            migrationBuilder.RenameIndex(
                name: "IX_cagnottes_EntrepriseId",
                table: "cagnottes",
                newName: "IX_cagnottes_EntrepriseFk");

            migrationBuilder.AddForeignKey(
                name: "FK_cagnottes_entreprises_EntrepriseFk",
                table: "cagnottes",
                column: "EntrepriseFk",
                principalTable: "entreprises",
                principalColumn: "EntrepriseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cagnottes_entreprises_EntrepriseFk",
                table: "cagnottes");

            migrationBuilder.RenameColumn(
                name: "EntrepriseFk",
                table: "cagnottes",
                newName: "EntrepriseId");

            migrationBuilder.RenameIndex(
                name: "IX_cagnottes_EntrepriseFk",
                table: "cagnottes",
                newName: "IX_cagnottes_EntrepriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_cagnottes_entreprises_EntrepriseId",
                table: "cagnottes",
                column: "EntrepriseId",
                principalTable: "entreprises",
                principalColumn: "EntrepriseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
