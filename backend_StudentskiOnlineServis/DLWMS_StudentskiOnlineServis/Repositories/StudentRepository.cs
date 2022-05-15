using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using DLWMS_StudentskiOnlineServis.Services.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        StudentResponse GetByID(int id);
        List<StudentResponse> GetAll();
        double GetProsjek(int id,int? godina=null);
    }

    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly DLWMS_baza baza;

        public StudentRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

        public List<StudentResponse> GetAll()
        {
            List<StudentResponse> studenti =
                baza.Studenti
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
                    CijenaSkolarine = student.CijenaSkolarine,
                    korisnickiNalog = new KorisnickiNalog
                    {
                        ID = student.ID,
                        KorisnickoIme = student.KorisnickoIme
                    }
                })
                .ToList();

            return studenti;
        }

        public StudentResponse GetByID(int id)
        {
            var student = baza.Studenti
                .Include(x => x.Fakultet)
                .FirstOrDefault(x => x.ID == id);

            if(student == null)
            {
                return null;
            }

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
                CijenaSkolarine = student.CijenaSkolarine,
                korisnickiNalog = new KorisnickiNalog
                {
                    ID = student.ID,
                    KorisnickoIme = student.KorisnickoIme
                }
            };
        }

        public double GetProsjek(int id, int? godina=null)
        {
            var result = baza.Uspjeh
                .Include(x => x.student_predmet)
                .ThenInclude(x => x.predmet)
                .Where(x => x.student_predmet.studentId == id)
                      .AsQueryable();

            if(godina.HasValue)
            {
                result = result.Where(x => x.student_predmet.predmet.Godina == godina);
            }

            return result.Average(x => x.ocjena);
        }
    }
}
