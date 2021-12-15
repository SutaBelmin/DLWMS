using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Data
{
    public class DLWMS_baza : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { set; get; }
        public DbSet<Fakultet> Fakulteti { set; get; }
        public DbSet<Verifikacija> Verifikacije { get; set; }
        public DLWMS_baza(DbContextOptions options) : base(options) { }

    }
}
