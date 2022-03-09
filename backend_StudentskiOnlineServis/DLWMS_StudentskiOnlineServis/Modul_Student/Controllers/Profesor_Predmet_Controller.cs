using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class Profesor_Predmet_Controller : ControllerBase
    {
        private readonly DLWMS_baza _baza;

        public Profesor_Predmet_Controller(DLWMS_baza baza)
        {
            this._baza = baza;
        }

        [HttpPost]
        public ActionResult AddProfesorPredmet(AddProfesorPredmetVM x)
        {
            var profesor_predmet = new Profesor_Predmet();

            profesor_predmet.profesorId = x.profesorId;
            profesor_predmet.predmetId = x.predmetId;

            _baza.Profesor_Predmet.Add(profesor_predmet);
            _baza.SaveChanges();

            return Ok();
        }
        [HttpGet]
        public object GetProfesorPredmet(int ProfesorID)
        {
            return _baza.Profesor_Predmet.Include(x=>x.predmet).Include(x=>x.profesor).Where(x => x.profesorId == ProfesorID).ToList();
        }
    }
}
