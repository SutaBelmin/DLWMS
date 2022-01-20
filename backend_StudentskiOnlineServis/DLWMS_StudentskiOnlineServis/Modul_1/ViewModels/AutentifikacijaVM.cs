using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.ViewModels
{
    public class AutentifikacijaLoginPostVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Fakultet_S { get; set; }
    }
    public class AutentifikcijaLoginResultVM
    {
        public string Poruka { get; set; }
        public string TokenString { get; set; }
        public string Username { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Korisnik { get; set; }
    }
}
