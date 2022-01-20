using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.ViewModels
{
    public class PostavljanjeVerifikacijeVM
    {
        public string mail { get; set; }
    }
    public class MailVM
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Sadrzaj { get; set; }
    }
}
