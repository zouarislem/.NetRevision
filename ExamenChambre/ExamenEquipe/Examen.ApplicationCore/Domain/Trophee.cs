using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Trophee
    {
        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }
        [DataType(DataType.Currency)]
        public double Recompense { get; set; }
        public int TropheeId { get; set; }
        public String TypeTropee { get; set; }
        public int EquipeFK { get; set; }

        public virtual Equipe Equipe { get; set; }

      
    }
}
