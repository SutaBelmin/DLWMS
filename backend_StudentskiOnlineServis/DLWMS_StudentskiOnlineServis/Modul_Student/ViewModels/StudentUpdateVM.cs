using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels
{
    public class StudentUpdateVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime? datum_rodjenja { get; set; }
        public string slika_studenta { get; set; }
        public int FakultetID { get; set; }
    }
}
