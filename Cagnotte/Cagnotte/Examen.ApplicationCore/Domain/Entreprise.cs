using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Entreprise
    {

        public string AdresseEntreprise { get; set; }
        public int EntrepriseId { get; set; }
        public string MailEntreprise { get; set; } 
        public string NomEntreprise { get; set; }


        public virtual List<Cagnotte> Cagnottes { get; set;}
    }
}
