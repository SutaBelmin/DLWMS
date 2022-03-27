using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Ocjena
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student student { get; set; }
        public int StudentID { get; set; }
        [ForeignKey(nameof(RokID))]
        public Rok rok { get; set; }
        public int RokID { get; set; }
        public int _Ocjena { get; set; }
    }
}
