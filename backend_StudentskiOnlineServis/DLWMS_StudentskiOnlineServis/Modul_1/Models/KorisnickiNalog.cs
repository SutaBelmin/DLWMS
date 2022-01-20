using DLWMS_StudentskiOnlineServis.Modul_1.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class KorisnickiNalog
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        [ForeignKey(nameof(FakultetID))]
        public Fakultet Fakultet { get; set; }
        public int FakultetID { get; set; }
        public string PrivatniEmail { get; set; }
        public string FakultetEmail { get; set; }
        [JsonIgnore]
        public Profesor Profesor => this as Profesor;
        public bool isProfesor => Profesor != null;
        public bool isAdmin { get; set; }

        //[JsonIgnore]
        //public Student student => this as Student;
        //public bool isStudent => student != null;

    }
}
