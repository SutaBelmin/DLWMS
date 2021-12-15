using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class AutentifikacijaToken
    {
        [Key]
        public int ID { get; set; }
        public string Vrijednost { get; set; }
        [ForeignKey(nameof(KorisnickiNalogId))]
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public int KorisnickiNalogId { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IP_Adresa { get; set; }
    }
}
