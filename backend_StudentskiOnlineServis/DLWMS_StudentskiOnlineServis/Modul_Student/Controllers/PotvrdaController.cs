using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentski_online_servis.Helper;
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
        public ActionResult GetAll(int? studentId)
        {
            var potvrde = _baza.Potvrda
                .Include(x => x.student)
                .Include(x => x.svrha)
                .AsQueryable();

            if (studentId.HasValue)
            {
                potvrde = potvrde.Where(x => x.studentId == studentId);
            }

            return Ok(potvrde.ToList());
        }

        [HttpPost]
        public ActionResult AddPotvrdu(AddPotvrdaVM x)
        {
            var potvrda = new Potvrda();
            potvrda.studentId = HttpContext.GetLoginInfo().korisnickiNalog.student.ID;
            potvrda.svrhaId = x.svrhaId;
            potvrda.Opis = x.Opis;

            _baza.Potvrda.Add(potvrda);
            _baza.SaveChanges();

            return Ok();
        }

        [HttpPost("{id}")]
        public ActionResult IzdajPotvrdu(int id)
        {
            var potvrda = _baza.Potvrda.Find(id);
            potvrda.Izdata = true;
            potvrda.referentId = HttpContext.GetLoginInfo().korisnickiNalog.referent.ID;
            potvrda.datum_izdavanja = DateTime.Now;
            
            _baza.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult GetSvrhe()
        {
            var svrhe = _baza.SvrhaPotvrde.ToList();

            return Ok(svrhe);
        }


    }
}
