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

    public class Student_Predmet_Controller : ControllerBase
    {
        private readonly DLWMS_baza _baza;

        public Student_Predmet_Controller(DLWMS_baza baza)
        {
            this._baza = baza;
        }

        [HttpPost]
        public ActionResult AddStudentPredmet(AddStudentPredmetVM x)
        {
            var student_predmet = new Student_Predmet();

            student_predmet.studentId = x.studentId;
            student_predmet.predmetId = x.predmetId;
            student_predmet.isPolozio = false;
            _baza.Student_Predmet.Add(student_predmet);
            _baza.SaveChanges();

            return Ok();
        }
        [HttpGet ("predmetID")]
        public object GetStudentPredmetPodaci(int predmetID)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaProfesor)
            //    return BadRequest("Profesor nije logiran!");
            return _baza.Student_Predmet.Include(x=>x.predmet).Include(x=>x.student).Where(x => x.predmetId == predmetID && x.isPolozio==false).ToList();
        }
    }
}
