using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentski_online_servis.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaLoginController : ControllerBase
    {
        private DLWMS_baza _dbContext;
        public AutentifikacijaLoginController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }
        public class AutentifikacijaLoginPostVM
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public int Fakultet_S { get; set; }
        }
        public class AutentifikcijaLoginResultVM
        {
            public string Poruka { get; set; }
            public string TokenString { get; set; }
            public string Username { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Korisnik { get; set; }
        }

        [HttpPost]
        public string Login([FromBody] AutentifikacijaLoginPostVM x)
        {
            Korisnik k = _dbContext.Korisnici.Where(s => s.KorisnickoIme == x.Username && s.Lozinka == x.Password && s.Fakultet.ID == x.Fakultet_S).SingleOrDefault();
            if (k == null)
                return $"GRESKA";
            string p;
            if (k.Vrsta_Korisnika == VrstaKorisnika.Student)
                p = "student";
            else if (k.Vrsta_Korisnika == VrstaKorisnika.Profesor)
                p = "profesor";
            else
                p = "referent";
            string tokenString = TokenGenerator.Generate(5);
            _dbContext.Add(new AutentifikacijaToken
            {
                KorisnickiNalogId = k.ID,
                VrijemeEvidentiranja = DateTime.Now,
                Vrijednost = tokenString,
                IP_Adresa="1.2.3.4"
            });
            _dbContext.SaveChanges();

           
            return $"{tokenString} {p}";
        }


        [HttpDelete]
        public IActionResult Logout()
        {
            AutentifikacijaToken k = HttpContext.GetKorisnikOfAuthToken();
            if (k != null)
            {
                _dbContext.Remove(k);
                _dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
