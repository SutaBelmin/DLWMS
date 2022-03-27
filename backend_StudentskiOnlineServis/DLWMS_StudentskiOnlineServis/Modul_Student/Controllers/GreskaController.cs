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

    public class GreskaController:ControllerBase
    {
        private readonly DLWMS_baza baza;

        public GreskaController(DLWMS_baza baza)
        {
            this.baza = baza;
        }

        [HttpPost]
        public ActionResult PrijavaGreske(AddGreskaVM x)
        {
            var greska = new Greska();

            greska.Opis = x.Opis;
            greska.Datum_prijave = DateTime.Now;

            baza.Greska.Add(greska);
            baza.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var greske = baza.Greska.ToList();

            return Ok(greske);
        }
    }
}
