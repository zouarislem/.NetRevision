using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Patient
    {
        [Key]
    
        public string CIN { get; set; }

        [DataType(DataType.EmailAddress)]
        public string AdresseEmail { get; set; }
        public DateTime DateNaissance { get; set; }
       
        public int NumDossier { get; set; }
        public int NumTel { get; set; }
      public NomComplet NomComplet { get; set; }
        public virtual List<Chambre> chambres { get; set; }
        public virtual List <Admission> admissions { get; set; }

    }
}
