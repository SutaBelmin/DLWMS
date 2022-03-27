using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Studentski_online_servis.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ForumController : ControllerBase
    {
        private readonly DLWMS_baza baza;

        public ForumController(DLWMS_baza baza)
        {
            this.baza = baza;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var forum = baza.Forum.ToList();

            return Ok(forum);
        }

        [HttpPost]
        public ActionResult AddPitanje(AddPitanjeVM x)
        {
            var forum = new Forum();
            forum.Pitanje = x.Pitanje;
            forum.questionerId= HttpContext.GetLoginInfo().korisnickiNalog.student.ID;

            baza.Forum.Add(forum);
            baza.SaveChanges();

            return Ok();
        }


        [HttpPost("{id}")]
        public ActionResult AddOdgovor(int id, AddOdgovorVM x)
        {
            var forum = baza.Forum.Find(id);
            forum.Odgovor = x.Odgovor;
            forum.answererId= HttpContext.GetLoginInfo().korisnickiNalog.student.ID;

            baza.SaveChanges();

            return Ok();
        }
    }
}
