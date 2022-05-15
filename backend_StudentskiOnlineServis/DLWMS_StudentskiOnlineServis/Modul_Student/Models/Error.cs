using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Error
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }

        [ForeignKey(nameof(korisnickiNalog))]
        public int? KorisnickiNalogId { get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }

    }
}
