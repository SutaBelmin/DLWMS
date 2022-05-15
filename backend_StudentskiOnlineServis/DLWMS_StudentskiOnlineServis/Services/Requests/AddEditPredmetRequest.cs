using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services.Requests
{
    public class AddEditPredmetRequest
    {
        public string Naziv { get; set; }

        public string Oznaka { get; set; }

        public int Godina { get; set; }
    }
}
