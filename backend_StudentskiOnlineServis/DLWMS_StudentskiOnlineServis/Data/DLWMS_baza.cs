using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Data
{
    public class DLWMS_baza : DbContext
    {
        public DLWMS_baza(DbContextOptions options) : base(options) { }

    }
}
