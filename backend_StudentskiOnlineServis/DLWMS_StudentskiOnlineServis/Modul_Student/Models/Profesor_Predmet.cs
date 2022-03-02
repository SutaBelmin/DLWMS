using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Profesor_Predmet
    {
        public int Id { get; set; }
        
        [ForeignKey(nameof(profesor))]
        public int profesorId { get; set; }
        public Profesor profesor { get; set; }

        [ForeignKey(nameof(predmet))]
        public int predmetId { get; set; }
        public Predmet predmet { get; set; }
    }
}
