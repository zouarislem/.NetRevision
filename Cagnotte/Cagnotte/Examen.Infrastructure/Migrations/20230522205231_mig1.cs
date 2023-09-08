using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entreprises",
                columns: table => new
                {
                    EntrepriseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entreprises", x => x.EntrepriseId);
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
                name: "participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailParticipant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participants", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "cagnottes",
                columns: table => new
                {
                    CagnotteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SommeDemandée = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    EntrepriseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cagnottes", x => x.CagnotteId);
                    table.ForeignKey(
                        name: "FK_cagnottes_entreprises_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "entreprises",
                        principalColumn: "EntrepriseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CagnotteParticipant",
                columns: table => new
                {
                    CagnottesCagnotteId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CagnotteParticipant", x => new { x.CagnottesCagnotteId, x.ParticipantsParticipantId });
                    table.ForeignKey(
                        name: "FK_CagnotteParticipant_cagnottes_CagnottesCagnotteId",
                        column: x => x.CagnottesCagnotteId,
                        principalTable: "cagnottes",
                        principalColumn: "CagnotteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CagnotteParticipant_participants_ParticipantsParticipantId",
                        column: x => x.ParticipantsParticipantId,
                        principalTable: "participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participations",
                columns: table => new
                {
                    CagnotteFk = table.Column<int>(type: "int", nullable: false),
                    ParticipantFk = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participations", x => new { x.CagnotteFk, x.ParticipantFk });
                    table.ForeignKey(
                        name: "FK_participations_cagnottes_CagnotteFk",
                        column: x => x.CagnotteFk,
                        principalTable: "cagnottes",
                        principalColumn: "CagnotteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_participations_participants_ParticipantFk",
                        column: x => x.ParticipantFk,
                        principalTable: "participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CagnotteParticipant_ParticipantsParticipantId",
                table: "CagnotteParticipant",
                column: "ParticipantsParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_cagnottes_EntrepriseId",
                table: "cagnottes",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_participations_ParticipantFk",
                table: "participations",
                column: "ParticipantFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CagnotteParticipant");

            migrationBuilder.DropTable(
                name: "Exemples");

            migrationBuilder.DropTable(
                name: "participations");

            migrationBuilder.DropTable(
                name: "cagnottes");

            migrationBuilder.DropTable(
                name: "participants");

            migrationBuilder.DropTable(
                name: "entreprises");
        }
    }
}
