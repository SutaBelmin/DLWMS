using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Services;
using DLWMS_StudentskiOnlineServis.Services.Requests;
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
        private readonly IGreskaService greskaService;

        public GreskaController(IGreskaService greskaService)
        {
            this.greskaService = greskaService;
        }

        [HttpPost]
        public ActionResult PrijavaGreske(AddGreskaRequest x)
        {
            greskaService.PrijavaGreske(x);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(greskaService.GetAll());
        }
    }
}
