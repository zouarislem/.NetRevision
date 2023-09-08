﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamContext))]
    [Migration("20230522220547_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CagnotteParticipant", b =>
                {
                    b.Property<int>("CagnottesCagnotteId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsParticipantId")
                        .HasColumnType("int");

                    b.HasKey("CagnottesCagnotteId", "ParticipantsParticipantId");

                    b.HasIndex("ParticipantsParticipantId");

                    b.ToTable("CagnotteParticipant");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Cagnotte", b =>
                {
                    b.Property<int>("CagnotteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CagnotteId"));

                    b.Property<DateTime>("DateLimite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntrepriseFk")
                        .HasColumnType("int");

                    b.Property<int>("SommeDemandée")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("CagnotteId");

                    b.HasIndex("EntrepriseFk");

                    b.ToTable("cagnottes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Entreprise", b =>
                {
                    b.Property<int>("EntrepriseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntrepriseId"));

                    b.Property<string>("AdresseEntreprise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailEntreprise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEntreprise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntrepriseId");

                    b.ToTable("entreprises");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Exemple", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Exemples");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticipantId"));

                    b.Property<string>("MailParticipant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipantId");

                    b.ToTable("participants");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Participation", b =>
                {
                    b.Property<int>("CagnotteFk")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantFk")
                        .HasColumnType("int");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.HasKey("CagnotteFk", "ParticipantFk");

                    b.HasIndex("ParticipantFk");

                    b.ToTable("participations");
                });

            modelBuilder.Entity("CagnotteParticipant", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Cagnotte", null)
                        .WithMany()
                        .HasForeignKey("CagnottesCagnotteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Participant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Cagnotte", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Entreprise", "entreprise")
                        .WithMany("Cagnottes")
                        .HasForeignKey("EntrepriseFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("entreprise");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Participation", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Cagnotte", "cagnotte")
                        .WithMany("Participations")
                        .HasForeignKey("CagnotteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Participant", "Participant")
                        .WithMany("Participations")
                        .HasForeignKey("ParticipantFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("cagnotte");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Cagnotte", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Entreprise", b =>
                {
                    b.Navigation("Cagnottes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Participant", b =>
                {
                    b.Navigation("Participations");
                });
#pragma warning restore 612, 618
        }
    }
}
