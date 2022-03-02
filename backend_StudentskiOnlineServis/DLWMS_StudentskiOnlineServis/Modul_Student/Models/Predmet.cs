using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Predmet
    {
        [Key]
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Oznaka { get; set; }
         
    }
}
