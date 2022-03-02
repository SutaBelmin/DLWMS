using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Student_Predmet
    {
        public int Id { get; set; }

        [ForeignKey(nameof(student))]
        public int studentId { get; set; }
        public Student student { get; set; }

        [ForeignKey(nameof(predmet))]
        public int predmetId { get; set; }
        public Predmet predmet { get; set; }

    }
}
