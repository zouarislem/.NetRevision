using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Clinique
    {

        public string Adresse { get; set; }
        public int Capacity { get; set; }
        public int CliniqueId { get; set; }
        public int NumTel { get; set; }

        public virtual  List<Chambre> Chambres { get; set; }
    }
}
