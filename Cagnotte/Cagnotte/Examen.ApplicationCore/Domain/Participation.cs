using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Participation
    {
        public int CagnotteFk { get; set; }
        public int Montant { get; set; } 
        public int ParticipantFk { get; set; }
        [ForeignKey("CagnotteFk")]
        public virtual Cagnotte cagnotte { get; set; }

        [ForeignKey("ParticipantFk")]
        public virtual Participant Participant { get; set; }
    }
}
