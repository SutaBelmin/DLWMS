using DLWMS_StudentskiOnlineServis.Modul_Referent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Potvrda
    {
        public int Id { get; set; }

        [ForeignKey(nameof(student))]
        public int studentId { get; set; }
        public Student student { get; set; }

        [ForeignKey(nameof(referent))]
        public int? referentId { get; set; }
        public Referent referent { get; set; }

        public bool Izdata { get; set; }

        public string Opis { get; set; }

        [ForeignKey(nameof(svrha))]
        public int svrhaId { get; set; }
        public SvrhaPotvrde svrha { get; set; }

        public DateTime datum_izdavanja { get; set; }
    }
}
