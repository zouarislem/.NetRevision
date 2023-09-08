using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{

    public enum TypeChambre
    {
        Simple, Double
    }
    public class Chambre
    {
        [Key]
        public int NumeroChambre { get; set; }
        public float Prix { get; set; }
        public TypeChambre TypeChambre { get; set; }
        public int CliniqueFk { get; set; }

        public virtual List<Patient> Patients { get; set; }
        public virtual Clinique Clinique { get; set; }

        public virtual List<Admission> Admissions { get; set;}
    }
}
