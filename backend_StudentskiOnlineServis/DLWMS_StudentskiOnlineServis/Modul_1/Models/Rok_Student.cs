using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Rok_Student
    {
        [Key]
        public int ID { get; set; }
        //ROK
        [ForeignKey(nameof(RokID))]
        public Rok Rok { get; set; }
        public int RokID { get; set; }
        //STUDENT
        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
        public int StudentID { get; set; }
        //ODGOVOR
        [ForeignKey(nameof(OdgovorID))]
        public Odgovor Odgovor { get; set; }
        public int OdgovorID { get; set; }
        //STUDENT ZAOKRUZIO
        public bool StudentZaokruzio { get; set; }
    }
}
