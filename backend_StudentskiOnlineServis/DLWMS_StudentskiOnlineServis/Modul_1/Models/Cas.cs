using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Cas
    {
        [Key]
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public string Lekcija { get; set; }
        [ForeignKey(nameof(PredmetID))]
        public Predmet Predmet { get; set; }
        public int PredmetID { get; set; }
        [ForeignKey(nameof(ProfesorID))]
        public Profesor Profesor { get; set; }
        public int ProfesorID { get; set; }
    }
}
