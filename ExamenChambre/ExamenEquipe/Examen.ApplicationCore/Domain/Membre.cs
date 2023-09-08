using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Membre
    {
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        [Key]
        public int Identifiant { get; set; }
        [Required(ErrorMessage = "Champs Obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Champs Obligatoire")]

        public String prenom { get; set; }


        public virtual List<Equipe> equipes { get; set; }
        public virtual List<Contrat> contrats { get; set; }
    }
}
