using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Rok
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(ProfesorID))]
        public Profesor Profesor { get; set; }
        public int ProfesorID { get; set; }
        [ForeignKey(nameof(Id_Predmet))]
        public Predmet Predmet { get; set; }
        public int Id_Predmet { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public string? NazivTesta { get; set; }
        public int? BrojPitanja { get; set; }
        public bool? Aktivan { get; set; }
    }
}
