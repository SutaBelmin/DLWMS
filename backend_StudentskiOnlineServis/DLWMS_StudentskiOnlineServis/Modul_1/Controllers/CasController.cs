using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentski_online_servis.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CasController : Controller
    {
        private DLWMS_baza _dbContext;
        public CasController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public object GetCasove(int ID)
        {
            return _dbContext.Casovi.Include(x => x.Predmet).Include(x => x.Profesor).Where(x => x.ProfesorID == ID).ToList();
        }
        public class CasVM
        {
            public DateTime Datum { get; set; }
            public string Lekcija { get; set; }
            public int PredmetID { get; set; }
            public int ProfesorID { get; set; }
        }
        [HttpPost]
        public ActionResult AddCas([FromBody] CasVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaProfesor)
                return BadRequest("Profesor nije logiran!");
            bool checkPredmet = _dbContext.Predmet.Where(a => a.Id == x.PredmetID).Count() > 0;
            bool checkProfesor = _dbContext.Profesori.Where(a => a.ID == x.ProfesorID).Count() > 0;
            if (!checkPredmet || !checkProfesor)
                return BadRequest("Greska");
            Cas n = new Cas()
            {
                Datum = x.Datum,
                Lekcija = x.Lekcija,
                PredmetID = x.PredmetID,
                ProfesorID = x.ProfesorID
            };
            _dbContext.Add(n);
            _dbContext.SaveChanges();
            return Ok(n);
        }
        public class IDVM
        {
            public int ID { get; set; }
        }
        [HttpDelete]
        public ActionResult ObrisiCas(int ID)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaProfesor)
                return BadRequest("Profesor nije logiran!");
            var cas = _dbContext.Casovi.Where(x => x.ID == ID).FirstOrDefault();
            if (cas == null)
                return BadRequest("Greska");
            List<Prisustvo> prisustva = _dbContext.Prisustva.Where(x => x.CasID == cas.ID).ToList();
            if (prisustva.Count() > 0)
            {
                foreach (Prisustvo p in prisustva)
                {
                    _dbContext.Prisustva.Remove(p);
                    _dbContext.SaveChanges();
                }
            }
            _dbContext.Casovi.Remove(cas);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
