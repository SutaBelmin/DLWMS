using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services.Requests
{
    public class AddErrorRequest
    {
        public string Message { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public int? KorisnickiNalogId { get; set; }
    }
}
