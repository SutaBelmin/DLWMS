using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_1.ViewModels;
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
    public class PasswordController : ControllerBase
    {
        private DLWMS_baza _dbContext;
        public PasswordController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public string PromjeniPassword([FromBody] PromjenaPasswordaVM y)
        {
            var k = _dbContext.KorisnickiNalog.Where(x => x.KorisnickoIme == y.BrojDosijea).FirstOrDefault();
            if (k == null)
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
            KorisnickiNalog k = _dbContext.KorisnickiNalog.Where(x => x.PrivatniEmail == email).FirstOrDefault();
            if (k == null)
                return $"Greska";
            return k.KorisnickoIme;
        }
        [HttpPost("{kod}")]
        public string IzbrisiVerifikaciju(string kod)
        {
            Verifikacija v = _dbContext.Verifikacije.Where(x => x.Token == kod).FirstOrDefault();
            _dbContext.Verifikacije.Remove(v);
            _dbContext.SaveChanges();
            return $"Izbrisana verifikacija!";
        }
    }
}
