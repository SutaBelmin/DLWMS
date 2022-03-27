using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Greska
    {
        public int Id { get; set; }

        public string Opis { get; set; }

        public DateTime Datum_prijave { get; set; }
    }
}
