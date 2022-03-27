using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
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
    public class Rok_StudentController : Controller
    {
        private DLWMS_baza _dbContext;
        public Rok_StudentController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }
        public class OdgovorNaPitanjeVM
        {
            public int RokID { get; set; }
            public int StudentID { get; set; }
            public int OdgovorID { get; set; }
            public bool StudentZaokruzio { get; set; } = false;
        }
        [HttpPost]
        public ActionResult OdgovorNaPitanje([FromBody] OdgovorNaPitanjeVM x)
        {
            var rok = _dbContext.Rokovi.Where(a => a.ID == x.RokID).FirstOrDefault();
            var student = _dbContext.Studenti.Where(a => a.ID == x.StudentID).FirstOrDefault();
            var odgovor = _dbContext.Odgovori.Where(a => a.ID == x.OdgovorID).FirstOrDefault();
            if (rok == null || student == null || odgovor == null)
                return BadRequest("ROK || STUDENT || ODGOVOR = NULL");
            Rok_Student novi = new Rok_Student()
            {
                RokID = x.RokID,
                StudentID = x.StudentID,
                OdgovorID = x.OdgovorID,
                StudentZaokruzio = x.StudentZaokruzio
            };
            _dbContext.Add(novi);
            _dbContext.SaveChanges();
            return Ok(novi);
        }
        [HttpGet]
        public object GetOdgovoreByStudentID(int StudentID)
        {
            return _dbContext.OdgovoriNaPitanja.Include(x => x.Odgovor).Where(x => x.StudentID == StudentID).ToList();
        }
        [HttpGet]
        public object GetPitanjaByStudentID(int StudentID, int RokID)
        {
            List<Pitanje> pitanja = new List<Pitanje>();

            foreach (Rok_Student rok in _dbContext.OdgovoriNaPitanja.Include(x => x.Odgovor).Include(x => x.Odgovor.Pitanje).Where(x => x.RokID == RokID).ToList())
            {
                bool nadjen = true;
                foreach (Pitanje p in pitanja)
                {
                    if (rok.Odgovor.PitanjeID == p.ID)
                        nadjen = false;
                }
                if (nadjen)
                    pitanja.Add(rok.Odgovor.Pitanje);
            }
            return pitanja;
        }
        [HttpGet]
        public object GetOdgovoreByRokID(int RokID)
        {
            return _dbContext.OdgovoriNaPitanja.Include(x => x.Odgovor).Where(x => x.RokID == RokID).ToList();
        }
        [HttpGet]
        public object GetOdgovoreByRokIDandStudentID(int StudentID, int RokID)
        {
            return _dbContext.OdgovoriNaPitanja.Include(x => x.Odgovor).Where(x => x.StudentID == StudentID && x.RokID == RokID).ToList();
        }
        [HttpGet]
        public object GetRezultateByStudentIDandRokID(int StudentID, int RokID)
        {
            return _dbContext.OdgovoriNaPitanja
                .Include(x => x.Odgovor)
                .Include(x => x.Odgovor.Pitanje).Where(x => x.StudentID == StudentID && x.RokID == RokID).OrderBy(x => x.Odgovor.Pitanje.Indeks).ToList();
        }
        [HttpGet]
        public object GetStudenteByRokID(int RokID)
        {
            List<Student> studenti = new List<Student>();
            List<Rok_Student> odgovori = _dbContext.OdgovoriNaPitanja.Include(x => x.Student).Where(x => x.RokID == RokID).ToList();
            foreach (Rok_Student rok in odgovori)
            {
                bool NijeNadjen = true;
                foreach (Student s in studenti)
                {
                    if (rok.Student.ID == s.ID)
                        NijeNadjen = false;
                }
                if (NijeNadjen)
                    studenti.Add(rok.Student);
            }
            return studenti;
        }
        [HttpGet]
        public string GetTacnostOdgovora(int StudentID, int RokID)
        {
            List<Pitanje> pitanja = _dbContext.Pitanja
                                                .Include(x => x.Rok)
                                                .Include(x => x.Rok.Predmet).ToList();
            List<Odgovor> odgovori = _dbContext.Odgovori
                                                .Include(x => x.Pitanje).ToList();
            List<Rok_Student> StudentZaokruzio = _dbContext.OdgovoriNaPitanja
                                                            .Include(x => x.Odgovor).Where(x => x.StudentID == StudentID && x.RokID == RokID).ToList();
            int correct = 0;
            List<Pitanje> test = new List<Pitanje>();
            foreach (Pitanje p in pitanja)
            {
                bool n = false;
                foreach (Rok_Student r in StudentZaokruzio)
                {
                    if (p.ID == r.Odgovor.PitanjeID)
                    {
                        Pitanje a = test.Where(a => a.ID == r.Odgovor.PitanjeID).FirstOrDefault();
                        if (a == null)
                            test.Add(p);
                    }
                    if (r.StudentZaokruzio == r.Odgovor.Tacan && p.ID == r.Odgovor.PitanjeID) n = true;
                    if ((r.StudentZaokruzio != r.Odgovor.Tacan) && (p.ID == r.Odgovor.PitanjeID))
                    {
                        n = false;
                        break;
                    }
                }
                if (n) correct++;
            }
            return $"{correct}/{test.Count()}";
        }
        public class OcjenaVM
        {
            public int StudentID { get; set; }
            public int RokID { get; set; }
            public int Ocjena { get; set; }
        }
        [HttpPost]
        public ActionResult UpisiOcjenu([FromBody] OcjenaVM x)
        {
            var student = _dbContext.Studenti.Where(a => a.ID == x.StudentID).FirstOrDefault();
            var rok = _dbContext.Rokovi.Where(a => a.ID == x.RokID).FirstOrDefault();
            if (student == null || rok == null)
                return BadRequest("GRESKA -> STUDENT==NULL || ROK==NULL");
            if (x.Ocjena < 6 || x.Ocjena > 10)
                return BadRequest("Ocjena < 6 || Ocjena > 10");
            int provjera = _dbContext.Ocjene.Where(a => a.StudentID == x.StudentID && a.RokID == x.RokID).Count();
            if (provjera > 0)
                return BadRequest("Ocjena je već upisana");
            Ocjena ocjena = new Ocjena()
            {
                StudentID=x.StudentID,
                RokID=x.RokID,
                _Ocjena=x.Ocjena
            };
            _dbContext.Ocjene.Add(ocjena);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public object GetOcjeneSvihStudenata()
        {
            return _dbContext.Ocjene
                .Include(x=>x.rok)
                .Include(x=>x.student)
                .ToList();
        }
    }
}
