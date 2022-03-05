using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Uspjeh
    {
        public int Id { get; set; }

        [ForeignKey(nameof(student_predmet))]
        public int student_predmetId { get; set; }
        public Student_Predmet student_predmet { get; set; }

        [ForeignKey(nameof(profesor_predmet))]
        public int profesor_predmetId { get; set; }
        public Profesor_Predmet profesor_predmet { get; set; }

        public int ocjena { get; set; }

        public DateTime datum_upisa { get; set; }
    }
}
