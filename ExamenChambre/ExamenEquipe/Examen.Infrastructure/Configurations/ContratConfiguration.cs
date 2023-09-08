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
    public class ContratConfiguration : IEntityTypeConfiguration<Contrat>
    {
        public void Configure(EntityTypeBuilder<Contrat> builder)
        {
            builder.HasKey(c => new
            {
                c.EquipeFK,
                c.MembreFK,
                c.DureeMois
            });
        }
    }
}
