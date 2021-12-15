using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Fakultet
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
        public Fakultet(string Naziv, string Grad)
        {
            this.Naziv = Naziv;
            this.Grad = Grad;
        }
    }
}
