using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class TropheeConfiguration : IEntityTypeConfiguration<Trophee>
    {
        public void Configure(EntityTypeBuilder<Trophee> builder)
        {
            /*     builder.HasOne(t => t.Equipe)
                     .WithMany(t => t.Trophees)
             .HasForeignKey(t => t.EquipeFK);
              */
            builder.HasOne(p => p.Equipe)
                .WithMany(p => p.Trophees)
                .HasForeignKey(p => p.EquipeFK);
        }

    }
}
