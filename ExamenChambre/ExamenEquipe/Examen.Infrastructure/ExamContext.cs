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
        public DbSet<Equipe> equipes { get; set; }
        public DbSet<Trophee> Trophees { get; set; }
        public DbSet<Membre> Membrees { get; set; }
        public DbSet<Entraineur> entraineurs { get; set; }
        public DbSet<Joueur> joueurs { get; set; }
        public DbSet<Contrat> contrats { get; set; }

        //les dbsets
        public DbSet<Exemple> Exemples { get; set; }
        //....................
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=ExamenEquipes;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); //activer lazy loading
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfiguration(new ExempleConfiguration());
            modelBuilder.ApplyConfiguration( new ContratConfiguration());
            modelBuilder.ApplyConfiguration(new TropheeConfiguration());


            modelBuilder.Entity<Membre>()
                .HasDiscriminator<String>("Type")
                .HasValue<Entraineur>("E")
                .HasValue<Joueur>("J")
                .HasValue<Membre>("M");


           
            //...................
            //tpt 
            //tph => config
        }
     

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
    }
}
