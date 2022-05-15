using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using System;

namespace DLWMS_StudentskiOnlineServis.Services.Responses

{ 
    public class StudentResponse
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string broj_indeksa { get; set; }
        public DateTime datum_rodjenja { get; set; }
        public string slika_studenta { get; set; }
        public int fakultetID { get; set; }
        public Fakultet Fakultet { get; set; }
        public int korisnickiNalogID { get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }
        public int CijenaSkolarine { get; set; }

        
    }
}
