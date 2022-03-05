using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels
{
    public class AddOcjenaVM
    {
        public int student_predmetId { get; set; }
        
        public int profesor_predmetId { get; set; }

        public int ocjena { get; set; }

        public DateTime datum_upisa { get; set; }
    }
}
