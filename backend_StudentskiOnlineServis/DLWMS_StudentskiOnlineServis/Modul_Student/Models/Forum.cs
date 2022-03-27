using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Models
{
    public class Forum
    {
        public int Id { get; set; }

        public string Pitanje { get; set; }

        public string Odgovor { get; set; }

        [ForeignKey(nameof(studentQuestioner))]
        public int questionerId { get; set; }
        public Student studentQuestioner { get; set; }

        [ForeignKey(nameof(studentAnswerer))]
        public int? answererId { get; set; }
        public Student studentAnswerer { get; set; }
    }
}
