using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services.Requests
{
    public class PotvrdaGetByParamsRequest
    {
        public int? StudentId { get; set; }

        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; }
    }
}
