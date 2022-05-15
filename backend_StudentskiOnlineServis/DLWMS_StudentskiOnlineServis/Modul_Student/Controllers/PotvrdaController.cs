using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Services;
using DLWMS_StudentskiOnlineServis.Services.Requests;
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
        private readonly IPotvrdaService potvrdaService;

        public PotvrdaController(IPotvrdaService potvrdaService)
        {
            this.potvrdaService = potvrdaService;
        }

        [HttpGet]
        public ActionResult GetAll(int? studentId)
        {
            return Ok(potvrdaService.GetByParams(studentId));
        }

        [HttpPost]
        public ActionResult AddPotvrdu(AddPotvrdaRequest x)
        {
            x.studentId = HttpContext.GetLoginInfo().korisnickiNalog.student.ID;
            potvrdaService.AddPotvrdu(x);

            return Ok();
        }

        [HttpPost("{id}")]
        public ActionResult IzdajPotvrdu(int id)
        {
            var referentId = HttpContext.GetLoginInfo().korisnickiNalog.referent.ID;
            potvrdaService.IzdajPotvrdu(id, referentId);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetSvrhe()
        {
            return Ok(potvrdaService.GetSvrhe());

        }


    }
}
