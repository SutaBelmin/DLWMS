using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using DLWMS_StudentskiOnlineServis.Services;
using DLWMS_StudentskiOnlineServis.Services.Requests;
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
        private readonly IProfesor_PredmetService profesor_PredmetService;

        public Profesor_Predmet_Controller(IProfesor_PredmetService profesor_PredmetService)
        {
            this.profesor_PredmetService = profesor_PredmetService;
        }

        [HttpPost]
        public ActionResult AddProfesorPredmet(AddProfesorPredmetRequest x)
        {
            profesor_PredmetService.AddProfesorPredmet(x);
            return Ok();
        }
        [HttpGet]
        public List<Profesor_Predmet> GetProfesorPredmet(int ProfesorID)
        {
            return profesor_PredmetService.GetProfesorPredmet(ProfesorID);
        }
    }
}
