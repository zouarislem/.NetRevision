using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Equipe
    {
        public String AdresseLocal { get; set; }
        public int EquipeId { get; set; }
        public String Logo { get; set; }
        public String NomEquipe { get; set; }


        public virtual List<Trophee> Trophees { get; set;}
        public  virtual List<Membre> Membrees { get; set;}
       public virtual List<Contrat> contrats { get; set; }
        
    }
}
