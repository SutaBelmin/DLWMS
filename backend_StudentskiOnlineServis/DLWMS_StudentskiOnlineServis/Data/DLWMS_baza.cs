using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DLWMS_StudentskiOnlineServis.Data
{
    public class DLWMS_baza : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { set; get; }
        public DbSet<Fakultet> Fakulteti { set; get; }
        public DbSet<Verifikacija> Verifikacije { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public DLWMS_baza(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach(var entity in entityTypes)
            {
                var foreignKeys = entity.GetForeignKeys();
                foreach (var key in foreignKeys)
                {
                    key.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }
    }
}
