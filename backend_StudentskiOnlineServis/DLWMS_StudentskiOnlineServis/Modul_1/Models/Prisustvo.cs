using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Prisustvo
    {
        public int ID { get; set; }
        [ForeignKey(nameof(CasID))]
        public Cas Cas { get; set; }
        public int CasID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student student { get; set; }
        public int StudentID { get; set; }
    }
}
