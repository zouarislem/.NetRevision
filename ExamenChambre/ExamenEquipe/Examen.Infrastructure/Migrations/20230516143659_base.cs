using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipes",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomEquipe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipes", x => x.EquipeId);
                });

            migrationBuilder.CreateTable(
                name: "Exemples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membrees",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Poste = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membrees", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "Trophees",
                columns: table => new
                {
                    TropheeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTrophee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recompense = table.Column<double>(type: "float", nullable: false),
                    TypeTropee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophees", x => x.TropheeId);
                    table.ForeignKey(
                        name: "FK_Trophees_equipes_EquipeFK",
                        column: x => x.EquipeFK,
                        principalTable: "equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contrats",
                columns: table => new
                {
                    DureeMois = table.Column<int>(type: "int", nullable: false),
                    EquipeFK = table.Column<int>(type: "int", nullable: false),
                    MembreFK = table.Column<int>(type: "int", nullable: false),
                    DateContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salaire = table.Column<double>(type: "float", nullable: false),
                    equipe = table.Column<int>(type: "int", nullable: false),
                    membre = table.Column<int>(type: "int", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: true),
                    MembreIdentifiant = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrats", x => new { x.EquipeFK, x.MembreFK, x.DureeMois });
                    table.ForeignKey(
                        name: "FK_contrats_Membrees_MembreIdentifiant",
                        column: x => x.MembreIdentifiant,
                        principalTable: "Membrees",
                        principalColumn: "Identifiant");
                    table.ForeignKey(
                        name: "FK_contrats_equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "equipes",
                        principalColumn: "EquipeId");
                });

            migrationBuilder.CreateTable(
                name: "EquipeMembre",
                columns: table => new
                {
                    MembreesIdentifiant = table.Column<int>(type: "int", nullable: false),
                    equipesEquipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeMembre", x => new { x.MembreesIdentifiant, x.equipesEquipeId });
                    table.ForeignKey(
                        name: "FK_EquipeMembre_Membrees_MembreesIdentifiant",
                        column: x => x.MembreesIdentifiant,
                        principalTable: "Membrees",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeMembre_equipes_equipesEquipeId",
                        column: x => x.equipesEquipeId,
                        principalTable: "equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contrats_EquipeId",
                table: "contrats",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_contrats_MembreIdentifiant",
                table: "contrats",
                column: "MembreIdentifiant");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeMembre_equipesEquipeId",
                table: "EquipeMembre",
                column: "equipesEquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trophees_EquipeFK",
                table: "Trophees",
                column: "EquipeFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contrats");

            migrationBuilder.DropTable(
                name: "EquipeMembre");

            migrationBuilder.DropTable(
                name: "Exemples");

            migrationBuilder.DropTable(
                name: "Trophees");

            migrationBuilder.DropTable(
                name: "Membrees");

            migrationBuilder.DropTable(
                name: "equipes");
        }
    }
}
