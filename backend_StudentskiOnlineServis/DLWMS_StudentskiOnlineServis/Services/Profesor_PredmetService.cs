using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IProfesor_PredmetService
    {
        void AddProfesorPredmet(AddProfesorPredmetRequest x);

        List<Profesor_Predmet> GetProfesorPredmet(int ProfesorID);
    }
    public class Profesor_PredmetService : IProfesor_PredmetService
    {
        private readonly IProfesor_PredmetRepository profesor_PredmetRepository;

        public Profesor_PredmetService(IProfesor_PredmetRepository profesor_PredmetRepository)
        {
            this.profesor_PredmetRepository = profesor_PredmetRepository;
        }

        public void AddProfesorPredmet(AddProfesorPredmetRequest x)
        {
            var profesor_predmet = new Profesor_Predmet();

            profesor_predmet.profesorId = x.profesorId;
            profesor_predmet.predmetId = x.predmetId;

            profesor_PredmetRepository.Add(profesor_predmet);
            profesor_PredmetRepository.Commit();
        }

        public List<Profesor_Predmet> GetProfesorPredmet(int ProfesorID)
        {
            return profesor_PredmetRepository.GetProfesorPredmet(ProfesorID);
        }
    }
}
