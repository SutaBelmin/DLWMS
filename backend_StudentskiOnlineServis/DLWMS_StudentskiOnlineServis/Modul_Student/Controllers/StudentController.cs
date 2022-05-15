using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using DLWMS_StudentskiOnlineServis.Services;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using DLWMS_StudentskiOnlineServis.Services.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentski_online_servis.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IImageService imageService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public StudentController(IStudentService studentService, IWebHostEnvironment webHostEnvironment, IImageService imageService)
        {
            this.studentService = studentService;
            this.webHostEnvironment = webHostEnvironment;
            this.imageService = imageService;
        }

        [HttpPost]
        public ActionResult Add([FromBody] StudentAddRequest request)
        {
            var result = studentService.Add(request);
            return Ok(result.ID);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] StudentUpdateRequest x)
        {
            var result = studentService.Update(id, x);
            return Ok(GetByID(result.ID));
        }

        [HttpGet("{id}")]
        public StudentResponse GetByID(int id)
        {
           return studentService.GetByID(id);
        }

        [HttpGet]
        public ActionResult GetStudent()
        {
            var id= HttpContext.GetLoginInfo().korisnickiNalog.student.ID;
            return Ok(studentService.GetStudent(id)); 
        }

        [HttpGet]
        public List<StudentResponse> GetAll()
        {
            return studentService.GetAll();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            studentService.Delete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult UploadImage([FromForm] IFormFile file)
        {
            return Ok(imageService.UploadImage(file));
        }

        [HttpGet]
        public ActionResult GetProsjekByGodina(int godina, int studentId)
        {
            return Ok(studentService.GetProsjek(studentId, godina));
        }

        [HttpGet]
        public ActionResult GetUkupniProsjek(int studentId)
        {
            return Ok(studentService.GetProsjek(studentId));
        }

        [HttpPost("{id}")]
        public ActionResult EvidentirajSkolarinu(int id, int cijena)
        {
            studentService.EvidentirajSkolarinu(id, cijena);
            
            return Ok();    
        }

        [HttpGet]
        public ActionResult InternalServerError()
        {
            throw new ArgumentNullException("Test internal server error.");
        }

    }
}
