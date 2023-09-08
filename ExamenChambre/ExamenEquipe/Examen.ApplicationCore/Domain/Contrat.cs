using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Contrat
    {
        public DateTime DateContrat { get; set; }
        [Range (1,24)]
        public int DureeMois { get; set; }
        public int EquipeFK { get; set; }
        public int MembreFK { get; set; }
        public double Salaire { get; set; }
      
        
        [ForeignKey("EquipeFK")]
        public virtual int  equipe { get; set; }
      
        
        [ForeignKey("MembreFK")]
        public virtual int membre { get; set; }
    }
}
