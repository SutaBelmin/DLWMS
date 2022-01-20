using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_1.ViewModels;
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
    public class ProfesorController : ControllerBase
    {
        private DLWMS_baza dlwms_db;

        public ProfesorController(DLWMS_baza dbContext)
        {
            dlwms_db = dbContext;
        }

        [HttpPost]
        public ActionResult<Profesor> DodajProfesora([FromBody] ProfesorVM NoviKorisnik)
        {
            var _Profesor = new Profesor()
            {
                Ime = NoviKorisnik.Ime,
                Prezime = NoviKorisnik.Prezime,
                KorisnickoIme = NoviKorisnik.KorisnickoIme,
                Lozinka = NoviKorisnik.Lozinka,
                FakultetID = NoviKorisnik.FakultetID,
                PrivatniEmail = NoviKorisnik.PrivatniEmail,
                FakultetEmail = NoviKorisnik.FakultetEmail
            };
            dlwms_db.Add(_Profesor);
            dlwms_db.SaveChanges();
            return _Profesor;
        }
        [HttpGet]
        public object GetProfesore()
        {
            return dlwms_db.Profesori.Include(x => x.Fakultet).ToList();
        }

    }

}
