using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliniques",
                columns: table => new
                {
                    CliniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    NumTel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliniques", x => x.CliniqueId);
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
                name: "Patients",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdresseEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumDossier = table.Column<int>(type: "int", nullable: false),
                    NumTel = table.Column<int>(type: "int", nullable: false),
                    NomCompletPrenom = table.Column<string>(name: "NomComplet_Prenom", type: "nvarchar(max)", nullable: false),
                    NomCompletNom = table.Column<string>(name: "NomComplet_Nom", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Chambres",
                columns: table => new
                {
                    NumeroChambre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    TypeChambre = table.Column<int>(type: "int", nullable: false),
                    CliniqueFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chambres", x => x.NumeroChambre);
                    table.ForeignKey(
                        name: "FK_Chambres_Cliniques_CliniqueFk",
                        column: x => x.CliniqueFk,
                        principalTable: "Cliniques",
                        principalColumn: "CliniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    DateAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChambreFK = table.Column<int>(type: "int", nullable: false),
                    MotifAdmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbJours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => new { x.ChambreFK, x.PatientFK, x.DateAdmission });
                    table.ForeignKey(
                        name: "FK_Admissions_Chambres_ChambreFK",
                        column: x => x.ChambreFK,
                        principalTable: "Chambres",
                        principalColumn: "NumeroChambre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientFK",
                        column: x => x.PatientFK,
                        principalTable: "Patients",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChambrePatient",
                columns: table => new
                {
                    PatientsCIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    chambresNumeroChambre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChambrePatient", x => new { x.PatientsCIN, x.chambresNumeroChambre });
                    table.ForeignKey(
                        name: "FK_ChambrePatient_Chambres_chambresNumeroChambre",
                        column: x => x.chambresNumeroChambre,
                        principalTable: "Chambres",
                        principalColumn: "NumeroChambre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChambrePatient_Patients_PatientsCIN",
                        column: x => x.PatientsCIN,
                        principalTable: "Patients",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientFK",
                table: "Admissions",
                column: "PatientFK");

            migrationBuilder.CreateIndex(
                name: "IX_ChambrePatient_chambresNumeroChambre",
                table: "ChambrePatient",
                column: "chambresNumeroChambre");

            migrationBuilder.CreateIndex(
                name: "IX_Chambres_CliniqueFk",
                table: "Chambres",
                column: "CliniqueFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "ChambrePatient");

            migrationBuilder.DropTable(
                name: "Exemples");

            migrationBuilder.DropTable(
                name: "Chambres");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Cliniques");
        }
    }
}
