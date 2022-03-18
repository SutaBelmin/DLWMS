using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class CHAT
    {
        public int ID { get; set; }
        public string sadrzaj { get; set; }
        [ForeignKey(nameof(korisnik1_ID))]
        public KorisnickiNalog korisnik1 { get; set; }
        public int korisnik1_ID { get; set; }
        [ForeignKey(nameof(korisnik2_ID))]
        public KorisnickiNalog korisnik2{get; set;}
        public int korisnik2_ID { get; set; }
        public DateTime datumPoruke { get; set; }
    }
}
