using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services.Requests
{
    public class AddPotvrdaRequest
    {

        public string Opis { get; set; }

        public int svrhaId { get; set; }

        public int studentId { get; set; }
    }
}
