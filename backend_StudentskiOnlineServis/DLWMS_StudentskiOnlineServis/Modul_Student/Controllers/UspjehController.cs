using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
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

    public class UspjehController : ControllerBase
    {
        private readonly IUspjehService uspjehService;

        public UspjehController(IUspjehService uspjehService)
        {
            this.uspjehService = uspjehService;
        }

        [HttpPost]
        public ActionResult AddOcjenu(AddOcjenaRequest x)
        {
            uspjehService.AddOcjenu(x);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetListUspjeh()
        {
            var studId = HttpContext.GetLoginInfo().korisnickiNalog.student.ID;
            var uspjeh = uspjehService.GetListUspjeh(studId);

            return Ok(uspjeh);
        }
    }
}
