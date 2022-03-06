using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studentski_online_servis.Helper;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PrisustvoController : Controller
    {
        private DLWMS_baza _dbContext;
        public PrisustvoController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{casID}")]
        public object GetPrisustva(int casID)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaProfesor)
            //    return BadRequest("Profesor nije logiran!");
            if (casID == 0)
                return BadRequest("Greska pri upisivanju casa!");
            bool checkCas = _dbContext.Casovi.Where(x => x.ID == casID).Count() > 0;
            if (!checkCas)
                return BadRequest("Ne postoji cas");
            return _dbContext.Prisustva.Include(x => x.Cas).Include(x => x.student).Where(x => x.CasID == casID).ToList();
        }

        [HttpDelete("{prisustvoID}")]
        public ActionResult ObrisiPrisustvo(int prisustvoID)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaProfesor)
                return BadRequest("Profesor nije logiran!");
            var checkPrisustvo = _dbContext.Prisustva.Where(x => x.ID == prisustvoID).FirstOrDefault();
            if (checkPrisustvo == null)
                return BadRequest("Ne postoji prisustvo!");
            _dbContext.Remove(checkPrisustvo);
            _dbContext.SaveChanges();
            return Ok(checkPrisustvo);
        }
        public class AddPrisustvoVM
        {
            public int studentID { get; set; }
            public int casID { get; set; }
        }
        [HttpPost]
        public ActionResult AddPrisustvo([FromBody] AddPrisustvoVM x)
        {
            int studentID = x.studentID;
            int casID = x.casID;

            if (studentID == 0 || casID == 0)
                return BadRequest("Nisu poslani validni parametri");
            if (!HttpContext.GetLoginInfo().isPermisijaProfesor)
                return BadRequest("Profesor nije logiran!");
            bool checkCas = _dbContext.Casovi.Where(x => x.ID == casID).Count() > 0;
            if (!checkCas)
                return BadRequest("Ne postoji cas");
            bool duplikat = _dbContext.Prisustva.Where(a => a.StudentID == x.studentID && a.CasID==x.casID).Count() > 0;
            if (duplikat)
                return BadRequest("Duplikat!");
            bool checkStudent = _dbContext.Studenti.Where(x => x.ID == studentID).Count() > 0;
            if (!checkStudent)
                return BadRequest("Ne postoji student");
            Prisustvo n = new Prisustvo()
            {
                StudentID = studentID,
                CasID = casID
            };
            _dbContext.Add(n);
            _dbContext.SaveChanges();
            return Ok(n);
        }
    }
}
