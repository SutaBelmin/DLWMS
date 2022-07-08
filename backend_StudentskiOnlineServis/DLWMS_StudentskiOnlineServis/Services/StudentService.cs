using DLWMS_StudentskiOnlineServis.Exceptions;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using DLWMS_StudentskiOnlineServis.Services.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IStudentService
    {
        Student Add(StudentAddRequest request);
        Student Update(int id, StudentUpdateRequest x);
        void EvidentirajSkolarinu(int id, int cijena);
        void Delete(int id);
        StudentResponse GetByID(int id);
        List<StudentResponse> GetAll();
        StudentInfoResponse GetStudent(int id);
        double GetProsjek(int id, int? godina = null);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IAutentifikacijaTokenRepository autentifikacijaTokenRepository;
        private readonly IPotvrdaRepository potvrdaRepository;
        private readonly IForumRepository forumRepository;
        


        public StudentService(IStudentRepository studentRepository, IAutentifikacijaTokenRepository autentifikacijaTokenRepository,
            IPotvrdaRepository potvrdaRepository, IForumRepository forumRepository)
        {
            this.studentRepository = studentRepository;
            this.autentifikacijaTokenRepository = autentifikacijaTokenRepository;
            this.potvrdaRepository = potvrdaRepository;
            this.forumRepository = forumRepository;
        }

        public Student Add(StudentAddRequest request)
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

            studentRepository.Add(newStudent);
            studentRepository.Commit();

            return newStudent;
        }

        public void Delete(int id)
        {
            var tokens = autentifikacijaTokenRepository.GetByStudentId(id).ToArray();
            autentifikacijaTokenRepository.RemoveRange(tokens);


            var potvrda = this.potvrdaRepository.GetByParams(new PotvrdaGetByParamsRequest
            {
                StudentId = id,
                PagedResult = false
            });
            potvrdaRepository.RemoveRange(potvrda.Potvrde.ToArray());

            var forum = this.forumRepository.GetByParams(new ForumGetByParamsRequest
            {
                studentId = id
            });
            forumRepository.RemoveRange(forum.ToArray());

            studentRepository.Remove(id);
            studentRepository.Commit();

        }

        public void EvidentirajSkolarinu(int id, int cijena)
        {

            var student = studentRepository.Get(id);
            if (student == null)
                throw new NotFoundException("Student not found");
            student.CijenaSkolarine = cijena;

            studentRepository.Commit();
        }

        public List<StudentResponse> GetAll()
        {
            return studentRepository.GetAll();
        }

        public StudentResponse GetByID(int id)
        {
            var student = studentRepository.GetByID(id);
            if (student == null)
                throw new NotFoundException("Student not found");
            return student;
        }

        public double GetProsjek(int id, int? godina = null)
        {
            return studentRepository.GetProsjek(id, godina);
        }

        public StudentInfoResponse GetStudent(int id)
        {
            var student = studentRepository.Get(id);
            if (student == null)
                throw new NotFoundException("Student not found");
            return new StudentInfoResponse
            {
                skolarina = student.CijenaSkolarine,
                prosjek = studentRepository.GetProsjek(id)
            };
        }

        public Student Update(int id, StudentUpdateRequest x)
        {
            var student = studentRepository.Get(id);
            
            if (student == null)
                throw new NotFoundException ("pogresan ID");
            
            student.Ime = x.ime;
            student.Prezime = x.prezime;
            student.DatumRodjenja = x.datum_rodjenja;
            student.slika_studenta = x.slika_studenta;
            student.FakultetID = x.FakultetID;

            studentRepository.Commit();
            return student;
        }
    }
}
