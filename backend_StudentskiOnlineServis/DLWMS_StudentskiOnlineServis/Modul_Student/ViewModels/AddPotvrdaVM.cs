using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels
{
    public class AddPotvrdaVM
    {
        public int studentId { get; set; }
     
        public int referentId { get; set; }
        
        public bool Izdata { get; set; }

        public string Opis { get; set; }

        public int svrhaId { get; set; }
        
        public DateTime datum_izdavanja { get; set; }
    }
}
