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

    public class PredmetController : ControllerBase
    {
        private readonly IPredmetService predmetService;

        public PredmetController(IPredmetService predmetService)
        {
            this.predmetService = predmetService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(predmetService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(predmetService.GetById(id));
        }

        [HttpPost]
        public ActionResult AddPredmet(AddEditPredmetRequest x)
        {
            predmetService.AddPredmet(x);
            return Ok();   
        }

        [HttpPost("{id}")]
        public ActionResult EditPredmet(int id, AddEditPredmetRequest x)
        {
            predmetService.EditPredmet(id, x);
            return Ok();
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            predmetService.Delete(id);
            return Ok();
        }
    }
}
