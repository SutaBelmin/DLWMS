using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IStudent_PredmetService
    {
        void AddStudentPredmet(AddStudentPredmetRequest x);
        List<Student_Predmet> GetStudentPredmetPodaci(int predmetID);
    }
    public class Student_PredmetService : IStudent_PredmetService
    {
        private readonly IStudent_PredmetRepository student_PredmetRepository;

        public Student_PredmetService(IStudent_PredmetRepository student_PredmetRepository)
        {
            this.student_PredmetRepository = student_PredmetRepository;
        }

        public void AddStudentPredmet(AddStudentPredmetRequest x)
        {
            var student_predmet = new Student_Predmet();

            student_predmet.studentId = x.studentId;
            student_predmet.predmetId = x.predmetId;
            student_predmet.isPolozio = false;

            student_PredmetRepository.Add(student_predmet);
            student_PredmetRepository.Commit();
        }

        public List<Student_Predmet> GetStudentPredmetPodaci(int predmetID)
        {
            return student_PredmetRepository.GetStudentPredmetPodaci(predmetID);
        }
    }
}
