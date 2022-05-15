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

    public class Student_Predmet_Controller : ControllerBase
    {
        private readonly IStudent_PredmetService student_PredmetService;

        public Student_Predmet_Controller(IStudent_PredmetService student_PredmetService)
        {
            this.student_PredmetService = student_PredmetService;
        }

        [HttpPost]
        public ActionResult AddStudentPredmet(AddStudentPredmetRequest x)
        {
            student_PredmetService.AddStudentPredmet(x);
            return Ok();
        }

        [HttpGet ("predmetID")]
        public List<Student_Predmet> GetStudentPredmetPodaci(int predmetID)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaProfesor)
            //    return BadRequest("Profesor nije logiran!");
            return student_PredmetService.GetStudentPredmetPodaci(predmetID);
        }
    }
}
