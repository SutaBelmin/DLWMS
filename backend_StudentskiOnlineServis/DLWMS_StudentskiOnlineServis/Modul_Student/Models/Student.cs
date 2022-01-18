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
        public string broj_indeksa { get; set; }
        public string slika_studenta { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
