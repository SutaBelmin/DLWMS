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
    public class TestController : Controller
    {
        private DLWMS_baza _dbContext;
        public TestController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
            PodesavanjaIndeksa.Podesi(_dbContext);
        }

        public class TestVM
        {
            public int ID { get; set; }
            public string NazivTesta { get; set; }
            public int BrojPitanja { get; set; }
        }
        [HttpPost]
        public ActionResult AddTest([FromBody] TestVM x)
        {
            var rok = _dbContext.Rokovi.Where(a => a.ID == x.ID).FirstOrDefault();
            if (rok == null)
                return BadRequest("Ne postoji rok!");
            rok.NazivTesta = x.NazivTesta;
            rok.BrojPitanja = x.BrojPitanja;
            _dbContext.SaveChanges();
            return Ok(rok);
        }
        [HttpGet]
        public object GetTests()
        {
            return _dbContext.Rokovi
                .Include(x => x.Predmet)
                .ToList();
        }
        public class PitanjeVM
        {
            public string Sadrzaj { get; set; }
            public int ID_rok { get; set; }
        }
        [HttpPost]
        public ActionResult AddPitanje([FromBody] PitanjeVM x)
        {

            Pitanje n = new Pitanje()
            {
                Sadrzaj = x.Sadrzaj,
                RokID = x.ID_rok
            };
            _dbContext.Pitanja.Add(n);
            _dbContext.SaveChanges();
            return Ok(n);
        }
        [HttpGet]
        public object GetPitanja()
        {
            return _dbContext.Pitanja.Include(x => x.Rok).ToList();
        }
        [HttpGet("{rokID}")]
        public object GetPitanjaByID_Rok(int rokID)
        {
            return
                _dbContext
                .Pitanja
                .Where(x => x.RokID == rokID)
                .Include(x => x.Rok)
                .ToList();
        }
        public class OdgovorVM
        {
            public string SadrzajOdgovora { get; set; }
            public bool Tacan { get; set; }
            public int ID_Pitanja { get; set; }
        }
        [HttpPost]
        public ActionResult AddOdgovor([FromBody] OdgovorVM x)
        {
            Odgovor n = new Odgovor()
            {
                SadrzajOdgovora = x.SadrzajOdgovora,
                Tacan = x.Tacan,
                PitanjeID = x.ID_Pitanja
            };
            _dbContext.Odgovori.Add(n);
            _dbContext.SaveChanges();
            return Ok(n);
        }
        [HttpGet]
        public object GetOdgovore()
        {
            return _dbContext.Odgovori
                .Include(x => x.Pitanje)
                .Include(x => x.Pitanje.Rok)
                .Include(x => x.Pitanje.Rok.Predmet)
                .Include(x => x.Pitanje.Rok.Profesor)
                .ToList();
        }
        [HttpGet("{ID_pitanja}")]
        public object GetOdgovoreByIDPitanja(int ID_pitanja)
        {
            return _dbContext.Odgovori
                .Include(x => x.Pitanje)
               .Include(x => x.Pitanje.Rok)
                .Include(x => x.Pitanje.Rok.Predmet)
                .Include(x => x.Pitanje.Rok.Profesor)
                .Where(x => x.PitanjeID == ID_pitanja)
                .ToList();
        }
        [HttpDelete("{ID_Odgovor}")]
        public void IzbrisiOdgovor(int ID_Odgovor)
        {
            Odgovor o = _dbContext.Odgovori.Where(x => ID_Odgovor == x.ID).FirstOrDefault();
            _dbContext.Odgovori.Remove(o);
            _dbContext.SaveChanges();
        }
        public class EditPitanja
        {
            public int ID_pitanja { get; set; }
            public string Sadrzaj { get; set; }
        }
        [HttpPost]
        public void EditujPitanje([FromBody] EditPitanja y)
        {
            Pitanje edit = _dbContext.Pitanja.Where(x => x.ID == y.ID_pitanja).FirstOrDefault();
            edit.Sadrzaj = y.Sadrzaj;
            _dbContext.SaveChanges();
        }
        [HttpDelete("{ID_Pitanja}")]
        public void IzbrisiPitanje(int ID_Pitanja)
        {
            List<Odgovor> os = _dbContext.Odgovori.Where(x => x.PitanjeID == ID_Pitanja).ToList();
            foreach (Odgovor o in os)
            {
                _dbContext.Odgovori.Remove(o);
            }
            Pitanje p = _dbContext.Pitanja.Where(x => x.ID == ID_Pitanja).FirstOrDefault();
            _dbContext.Pitanja.Remove(p);
            _dbContext.SaveChanges();
        }
    }
}
