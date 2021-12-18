using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string broj_indeksa { get; set; }
        public DateTime? datum_rodjenja { get; set; }
        public string slika_studenta { get; set; }

        [ForeignKey(nameof(Fakultet))]
        public int FakultetID { get; set; }
        public Fakultet Fakultet { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogID { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
