using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Produit
    {
        [DataType(DataType.Date,ErrorMessage ="Invalide!") ]
        public DateTime DateProd { get; set; }
        public String Nom { get; set; }
        public String Destination { get; set; }
        public double Price { get; set; }
        public int ProduitId { get; set; }

        [ForeignKey("CategorieFK")]
        public virtual Categorie Categorie { get; set; }
        

        public int CategorieFK { get; set; }
        public virtual List<Fournisseur> Fournisseurs { get; set; }

    }
}
