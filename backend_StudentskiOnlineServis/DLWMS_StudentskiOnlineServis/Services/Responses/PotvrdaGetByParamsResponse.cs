using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using System.Collections.Generic;

namespace DLWMS_StudentskiOnlineServis.Services.Responses
{
    public class PotvrdaGetByParamsResponse
    {
        public int NumberOfRecords { get; set; }

        public IEnumerable<Potvrda> Potvrde { get; set; }
    }
}
