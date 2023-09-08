using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Admission
    {

        [DataType(DataType.Date)]
        public DateTime DateAdmission { get; set; }

        [DataType(DataType.MultilineText), Display(Name = "Le motif del'admission")]
        public string MotifAdmission { get; set; }
        public int NbJours { get; set; }
        public string PatientFK {get; set; }
        public int ChambreFK { get; set; }
        [ForeignKey(nameof(ChambreFK))]
        public virtual Chambre Chambre { get; set; }
        [ForeignKey(nameof(PatientFK))]

        public virtual Patient Patient  { get; set; }
    }
}
