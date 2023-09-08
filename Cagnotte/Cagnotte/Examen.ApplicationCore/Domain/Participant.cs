﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Participant
    {
        public string MailParticipant { get; set; }
        public string Nom { get; set; }
        public int ParticipantId { get; set; }
        public string Prenom { get; set; }
        public virtual List<Cagnotte> Cagnottes { get; set; }
        public virtual List<Participation> Participations { get; set; }


    }
}
