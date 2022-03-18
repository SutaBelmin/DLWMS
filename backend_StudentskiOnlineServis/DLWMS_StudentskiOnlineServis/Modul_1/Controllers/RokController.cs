using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RokController : Controller
    {
        private DLWMS_baza _dbContext;
        public RokController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public object GetActiveRokovi(int StudentID)
        {
            List<Rok_Student> uradjeniRokovi = _dbContext.OdgovoriNaPitanja.Where(x => x.StudentID == StudentID).ToList();
            if (uradjeniRokovi.Count() == 0)
                return _dbContext.Rokovi
                    .Include(x => x.Predmet)
                    .Where(x => x.Aktivan == true).ToList();
            else
            {
                List<Rok> rokovi = _dbContext.Rokovi
                    .Include(x => x.Predmet)
                    .Where(x => x.Aktivan == true).ToList();
                List<Rok> ForDelete = new List<Rok>();
                foreach (Rok_Student RokStudent in uradjeniRokovi)
                {
                    foreach (Rok rok in rokovi)
                    {
                        if (RokStudent.RokID == rok.ID && RokStudent.StudentID == StudentID)
                            ForDelete.Add(rok);
                    }
                }
                foreach (Rok rok1 in ForDelete)
                    rokovi.Remove(rok1);

                return rokovi;
            }
        }
        public class RokVM
        {

            public int PredmetID { get; set; }
            public int ProfesorID { get; set; }
            public DateTime DatumOdrzavanja { get; set; }
        }
        [HttpPost]
        public ActionResult AddRok([FromBody] RokVM rok)
        {
            bool ProvjeraPredmeta = _dbContext.Predmet.Where(x => x.Id == rok.PredmetID).Count() == 1;
            bool ProvjeraProfesora = _dbContext.Profesori.Where(x => x.ID == rok.ProfesorID).Count() == 1;
            if (ProvjeraPredmeta && ProvjeraProfesora)
            {
                Rok novi = new Rok()
                {
                    Id_Predmet = rok.PredmetID,
                    DatumOdrzavanja = rok.DatumOdrzavanja,
                    ProfesorID = rok.ProfesorID,
                    Aktivan = false,
                    NazivTesta = "TEST"
                };
                _dbContext.Rokovi.Add(novi);
                _dbContext.SaveChanges();
                return Ok(novi);
            }
            return BadRequest("Neispravni podaci -> profesorID || predmetID");
        }
        [HttpGet]
        public object GetRokove()
        {
            return _dbContext.Rokovi
                .Include(x => x.Predmet)
                .Include(x => x.Profesor)
                .ToList();
        }

        [HttpPost]
        public ActionResult ActivateTest(int ID)
        {
            var rok = _dbContext.Rokovi.Where(x => x.ID == ID).FirstOrDefault();
            if (rok == null)
                return BadRequest("Ne postoji rok!");
            rok.Aktivan = true;
            _dbContext.SaveChanges();
            return Ok(rok);
        }
        [HttpPost]
        public ActionResult DeactivateTest(int ID)
        {
            var rok = _dbContext.Rokovi.Where(x => x.ID == ID).FirstOrDefault();
            if (rok == null)
                return BadRequest("Ne postoji rok!");
            rok.Aktivan = false;
            _dbContext.SaveChanges();
            return Ok(rok);
        }
        [HttpGet("{profesorID}")]
        public object GetProsleRokoveByIDProfesora(int profesorID)
        {
            return _dbContext.Rokovi
                .Include(x => x.Predmet)
                .Include(x => x.Profesor)
                .Where(x => x.ProfesorID == profesorID && DateTime.Now >= x.DatumOdrzavanja)
                .ToList();
        }
        [HttpGet("{profesorID}")]
        public object GetSadasnjeRokoveByIDProfesora(int profesorID)
        {
            return _dbContext.Rokovi
                .Include(x => x.Predmet)
                .Include(x => x.Profesor)
                .Where(x => x.ProfesorID == profesorID && DateTime.Now < x.DatumOdrzavanja)
                .ToList();
        }

        [HttpGet("{rokID}")]
        public bool GetRokDateByID(int rokID)
        {
            var getRok = _dbContext.Rokovi.Where(a => a.ID == rokID).FirstOrDefault();
            if (getRok.DatumOdrzavanja < DateTime.Now)
                return true;
            else
                return false;
        }

        [HttpDelete("{rokID}")]
        public ActionResult Obrisi(int rokID)
        {
            Rok rok = _dbContext
                .Rokovi
                .Where(x => x.ID == rokID)
                .FirstOrDefault();
            if (rok == null) return BadRequest("Ne postoji rok!");
            _dbContext.Rokovi.Remove(rok);
            _dbContext.SaveChanges();
            return Ok(rok);
        }
    }
}
