using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Odgovor
    {
        [Key]
        public int ID { get; set; }
        public string SadrzajOdgovora { get; set; }
        public bool Tacan { get; set; }
        [ForeignKey(nameof(PitanjeID))]
        public Pitanje Pitanje { get; set; }
        public int PitanjeID { get; set; }

    }
}
