using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using System;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Student : KorisnickiNalog
    {
        public string broj_indeksa { get; set; }
        public string slika_studenta { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int CijenaSkolarine { get; set; }
    }
}
