using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Fournisseur
    {

        public string ConfirmPassword { get; set; } 
        public string Email { get; set; }
        [Key]
        public int Identifiant { get; set; }
        public bool IsApproved { get; set; }
        [Range(3,12)]
        public string Nom { get; set; }

        public virtual List<Produit> Produits { get; set;}

    }
}
