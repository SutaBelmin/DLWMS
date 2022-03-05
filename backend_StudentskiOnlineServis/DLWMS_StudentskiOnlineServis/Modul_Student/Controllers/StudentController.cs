using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
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
                broj_indeksa = request.broj_indeksa,
                slika_studenta = request.slika_studenta,
                Ime = request.ime,
                Prezime = request.prezime,
                DatumRodjenja = request.datum_rodjenja,
                FakultetID = request.FakultetID,
                KorisnickoIme = request.KorisnickoIme,
                Lozinka = request.Lozinka
            };

            _baza.Studenti.Add(newStudent);
            _baza.SaveChanges();
            return Ok(newStudent.ID);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] StudentUpdateVM x)
        {
            Student student = _baza.Studenti.Find(id);

            if (student == null)
                return BadRequest("pogresan ID");

            student.Ime = x.ime;
            student.Prezime = x.prezime;
            student.DatumRodjenja = x.datum_rodjenja;
            student.slika_studenta = x.slika_studenta;
            student.FakultetID = x.FakultetID;

            _baza.SaveChanges();
            return Ok(GetByID(id));
        }

        [HttpGet("{id}")]
        public StudentResponse GetByID(int id)
        {
            var student = _baza.Studenti
                .Include(x => x.Fakultet)
                .FirstOrDefault(x => x.ID == id);

            return new StudentResponse
            {
                id = student.ID,
                ime = student.Ime,
                prezime = student.Prezime,
                broj_indeksa = student.broj_indeksa,
                datum_rodjenja = student.DatumRodjenja,
                Fakultet = student.Fakultet,
                fakultetID = student.FakultetID,
                slika_studenta = student.slika_studenta,
                korisnickiNalog = new KorisnickiNalog
                {
                    ID = student.ID,
                    KorisnickoIme = student.KorisnickoIme
                }
            };
        }

        [HttpGet]
        public List<StudentResponse> GetAll(int id)
        {
            List<StudentResponse> studenti = 
                _baza.Studenti
                .Include(x => x.Fakultet)
                .Select(student => new StudentResponse
                {
                    id = student.ID,
                    ime = student.Ime,
                    prezime = student.Prezime,
                    broj_indeksa = student.broj_indeksa,
                    datum_rodjenja = student.DatumRodjenja,
                    Fakultet = student.Fakultet,
                    fakultetID = student.FakultetID,
                    slika_studenta = student.slika_studenta,
                    korisnickiNalog = new KorisnickiNalog
                    {
                        ID = student.ID,
                        KorisnickoIme = student.KorisnickoIme
                    }
                })
                .ToList();

            return studenti;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Student student = _baza.Studenti
                .FirstOrDefault(x => x.ID == id);

            if (student == null)
                return BadRequest("pogresan ID");

            _baza.Remove(student);

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

        [HttpGet]
        public ActionResult GetProsjekByGodina(int godina, int studentId)
        {
            var result = _baza.Uspjeh
                .Include(x=>x.student_predmet)
                .ThenInclude(x=>x.predmet)
                .Where(x => x.student_predmet.predmet.Godina == godina
                                           && x.student_predmet.studentId == studentId)
                                           .Average(x=>x.ocjena);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetUkupniProsjek(int studentId)
        {
            var result = _baza.Uspjeh
                .Include(x => x.student_predmet)
                .Where(x => x.student_predmet.studentId == studentId)
                      .Average(x => x.ocjena);
            return Ok(result);
        }



    }
}
