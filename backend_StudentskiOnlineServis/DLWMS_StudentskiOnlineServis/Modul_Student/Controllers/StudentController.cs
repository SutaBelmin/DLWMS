using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly DLWMS_baza _baza;
        private readonly IWebHostEnvironment webHostEnvironment;

        public StudentController(DLWMS_baza baza, IWebHostEnvironment webHostEnvironment)
        {
            this._baza = baza;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public ActionResult Add([FromBody] StudentAddVM request)
        {
            var newStudent = new Student
            {
                ime = request.ime,
                prezime = request.prezime,
                broj_indeksa = request.broj_indeksa,
                datum_rodjenja = request.datum_rodjenja,
                slika_studenta = request.slika_studenta,
                FakultetID = request.FakultetID,
                KorisnickiNalog = new Modul_1.Models.KorisnickiNalog
                {
                    KorisnickoIme = request.KorisnickoIme,
                    Lozinka = request.Lozinka
                }
            };

            _baza.Studenti.Add(newStudent);
            _baza.SaveChanges();
            return Ok(newStudent.id);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] StudentUpdateVM x)
        {
            Student student = _baza.Studenti.Find(id);

            if (student == null)
                return BadRequest("pogresan ID");

            student.ime = x.ime;
            student.prezime = x.prezime;
            student.datum_rodjenja = x.datum_rodjenja;
            student.slika_studenta = x.slika_studenta;
            student.FakultetID = x.FakultetID;

            _baza.SaveChanges();
            return Ok(GetByID(id));
        }

        [HttpGet("{id}")]
        public Student GetByID(int id)
        {
            var student = _baza.Studenti
                .Include(x => x.Fakultet)
                .Include(x => x.KorisnickiNalog)
                .FirstOrDefault(x => x.id == id);

            return student;
        }

        [HttpGet]
        public List<Student> GetAll(int id)
        {
            List<Student> studenti = _baza.Studenti
                .Include(x => x.Fakultet)
                .Include(x => x.KorisnickiNalog)
                .ToList();

            return studenti;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Student student = _baza.Studenti
                .Include(x => x.KorisnickiNalog)
                .FirstOrDefault(x => x.id == id);

            if (student == null)
                return BadRequest("pogresan ID");

            _baza.Remove(student);
            _baza.Remove(student.KorisnickiNalog);

            _baza.SaveChanges();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult UploadImage([FromForm] IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            if (file.Length > 0)
            {
                var path = Path.Combine(webHostEnvironment.WebRootPath, fileName);
                var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                using (var stream = System.IO.File.Create(path))
                {
                    memoryStream.Position = 0;
                    memoryStream.CopyTo(stream);
                }
            }
            return Ok(new
            {
                ImageUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/{fileName}"
            });
        }
    }
}
