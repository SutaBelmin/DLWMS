using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Pitanje
    {
        [Key]
        public int ID { get; set; }
        public int Indeks { get; set; } = 1;
        public string Sadrzaj { get; set; }
        [ForeignKey(nameof(RokID))]
        public Rok Rok { get; set; }
        public int RokID { get; set; }
    }
}
