using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public enum VrstaKorisnika
    {
        Student,
        Profesor,
        Referent
    }
    public class Korisnik : KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public VrstaKorisnika Vrsta_Korisnika { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumPrijave { get; set; }
        public string DLWMS_email { get; set; } = null;
        public string Privatni_email { get; set; } = null;
        [ForeignKey(nameof(FakultetID))]
        public Fakultet Fakultet { get; set; }
        public int FakultetID { get; set; }
    }
}
