using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum Type
    {

        CadeauCommun,DépenseàPlusieurs,ProjetSolidaire,Autres
    }
    public class Cagnotte

    {

        public int CagnotteId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string photo { get; set; }
        //[Range(1, int.MinValue)]
        public int SommeDemandée { get; set; }

        [Required(ErrorMessage ="Obligatoire!")]
        
        public string Titre { get; set; }
        public Type type { get; set; }

        public int EntrepriseFk { get; set; }
        [ForeignKey("EntrepriseFk")]
        public virtual Entreprise entreprise { get; set; }
        public virtual List<Participant> Participants { get; set; }
        public virtual List<Participation> Participations { get; set; }
     
    }
}
