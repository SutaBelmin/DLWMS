using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PasswordController
    {
        private DLWMS_baza _dbContext;
        public PasswordController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }
        public class PromjenaPasswordaVM
        {
            public string BrojDosijea { get; set; }
            public string Lozinka { get; set; }
            public string PonovnaLozinka { get; set; }
        }
        [HttpPost]
        public string PromjeniPassword([FromBody] PromjenaPasswordaVM y)
        {
            var k = _dbContext.Korisnici.Where(x => x.KorisnickoIme == y.BrojDosijea).FirstOrDefault();
            if(k==null)
                return $"Pogresan broj dosijea!";
            if (y.Lozinka != y.PonovnaLozinka)
                return $"Pogresno ponovno upisivanje lozinke!";
            k.Lozinka = y.Lozinka;
            _dbContext.SaveChanges();
            return $"Lozinka uspjesno promjenjena!";
        }
       
        [HttpGet]
        public string GetDosije(string email)
        {
            KorisnickiNalog k = _dbContext.Korisnici.Where(x => x.Privatni_email == email).FirstOrDefault();
            if (k == null)
                return $"Greska";
            return k.KorisnickoIme;
        }
        [HttpDelete ("{kod}")]
        public void IzbrisiVerifikaciju(string kod)
        {
            Verifikacija v = _dbContext.Verifikacije.Where(x => x.Token == kod).FirstOrDefault();
            _dbContext.Verifikacije.Remove(v);
            _dbContext.SaveChanges();
        }
    }
}
