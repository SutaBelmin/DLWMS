using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class PotvrdaController:ControllerBase
    {
        private readonly DLWMS_baza _baza;

        public PotvrdaController(DLWMS_baza baza)
        {
            this._baza = baza;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var potvrde = _baza.Potvrda.ToList();

            return Ok(potvrde);
        }

        [HttpPost]
        public ActionResult AddPotvrdu(AddPotvrdaVM x)
        {
            var potvrda = new Potvrda();
            potvrda.studentId = x.studentId;
            potvrda.svrhaId = x.svrhaId;
            potvrda.Opis = x.Opis;

            _baza.Potvrda.Add(potvrda);
            _baza.SaveChanges();

            return Ok();
        }


    }
}
