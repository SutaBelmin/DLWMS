using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_Referent.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.Modul_Admin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DLWMS_StudentskiOnlineServis.Data
{
    public class DLWMS_baza : DbContext
    {
        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; } //Briše se za sljedeći sprint
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { set; get; }
        public DbSet<Fakultet> Fakulteti { set; get; }
        public DbSet<Verifikacija> Verifikacije { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Profesor_Predmet> Profesor_Predmet { get; set; }
        public DbSet<Referent> Referent { get; set; }
        public DbSet<Student_Predmet> Student_Predmet { get; set; }
        public DbSet<Uspjeh> Uspjeh { get; set; }
        public DbSet<Potvrda> Potvrda { get; set; }
        public DbSet<SvrhaPotvrde> SvrhaPotvrde { get; set; }
        public DbSet<Greska> Greska { get; set; }
        public DbSet<Forum> Forum { get; set; }
        public DbSet<Error> Error { get; set; }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Cas> Casovi { get; set; }
        public DbSet<Prisustvo> Prisustva { get; set; }
        public DbSet<Rok> Rokovi { get; set; }
        public DbSet<Pitanje> Pitanja { get; set; }
        public DbSet<Odgovor> Odgovori { get; set; }
        public DbSet<Rok_Student> OdgovoriNaPitanja { get; set; }
        public DbSet<Ocjena> Ocjene { get; set; }
        public DbSet<CHAT> Poruke { get; set; }
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
