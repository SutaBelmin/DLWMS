using System;

namespace DLWMS_StudentskiOnlineServis.Services.Requests
{
    public class AddOcjenaRequest
    {
        public int student_predmetId { get; set; }
        
        public int profesor_predmetId { get; set; }

        public int ocjena { get; set; }

        public DateTime datum_upisa { get; set; }
    }
}
