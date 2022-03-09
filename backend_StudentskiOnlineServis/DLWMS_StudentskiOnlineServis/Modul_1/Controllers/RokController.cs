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
                    ProfesorID = rok.ProfesorID
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
                .Where(x => x.ProfesorID == profesorID && DateTime.Now<x.DatumOdrzavanja)
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
