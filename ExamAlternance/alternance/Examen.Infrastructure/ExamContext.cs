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
        public  DbSet<Produit> Produits { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Chimique> Chimiques { get; set; }
        public DbSet<Biologique> Biologiques { get; set; }
        //....................
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=Alternance;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); //activer lazy loading
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExempleConfiguration());
            //...................
            //tpt 
            //tph => config

            modelBuilder.Entity<Produit>()
                .HasMany(p => p.Fournisseurs)
                .WithMany(p => p.Produits)
                .UsingEntity(p => p.ToTable("Facture"));

            modelBuilder.Entity<Produit>()
                .HasDiscriminator<char>("TypeProduit")
                .HasValue<Produit>('p')
                .HasValue<Chimique>('c')
                .HasValue<Biologique>('b');

                
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            configurationBuilder.Properties<String>().HaveMaxLength(50);
            //configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
    }
}
