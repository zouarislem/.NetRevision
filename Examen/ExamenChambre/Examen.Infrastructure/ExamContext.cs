using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamContext:DbContext
    {
        //les dbsets
        public DbSet<Exemple> Exemples { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Clinique> Cliniques { get; set; }
        public DbSet<Admission> Admissions { get; set; }    
        public DbSet<Chambre> Chambres { get; set; }

        //....................
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=ExamenChambre;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); //activer lazy loading
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CliniqueConfiguration());


            modelBuilder.ApplyConfiguration(new ExempleConfiguration());
            //...................
            //tpt 
            //tph => config
            modelBuilder.Entity<Patient>()
                 .OwnsOne(p => p.NomComplet, NC =>
                 {
                     NC.Property(p => p.Nom);
                     NC.Property(p => p.Prenom);
                 });

            modelBuilder.Entity<Admission>()
                .HasKey(p => new
                {
                    p.ChambreFK,
                    p.PatientFK,
                    p.DateAdmission
                });

         
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
           
            //configurationBuilder.Properties<DateTime>().HaveColumnType("date");
          
        }

    }
}
