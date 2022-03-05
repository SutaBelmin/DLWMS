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

    public class UspjehController : ControllerBase
    {
        private readonly DLWMS_baza _baza;

        public UspjehController(DLWMS_baza baza)
        {
            this._baza = baza;
        }

        [HttpPost]
        public ActionResult AddOcjenu(AddOcjenaVM x)
        {
            var uspjeh = new Uspjeh();

            uspjeh.student_predmetId = x.student_predmetId;
            uspjeh.profesor_predmetId = x.profesor_predmetId;
            uspjeh.ocjena = x.ocjena;
            uspjeh.datum_upisa = x.datum_upisa;

            _baza.Uspjeh.Add(uspjeh);
            _baza.SaveChanges();

            return Ok();
        }
    }
}
