using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IPredmetService 
    {
        List<Predmet> GetAll();
        Predmet GetById(int id);
        void AddPredmet(AddEditPredmetRequest x);
        void EditPredmet(int id, AddEditPredmetRequest x);
        void Delete(int id);
    }
    public class PredmetService : IPredmetService
    {
        private readonly IPredmetRepository predmetRepository;

        public PredmetService(IPredmetRepository predmetRepository)
        {
            this.predmetRepository = predmetRepository;
        }

        public void AddPredmet(AddEditPredmetRequest x)
        {
            var predmet = new Predmet();

            predmet.Naziv = x.Naziv;
            predmet.Oznaka = x.Oznaka;
            predmet.Godina = x.Godina;

            predmetRepository.Add(predmet);
            predmetRepository.Commit();
        }

        public void Delete(int id)
        {
            predmetRepository.Remove(id);
            predmetRepository.Commit();
        }

        public void EditPredmet(int id, AddEditPredmetRequest x)
        {
            var predmet = predmetRepository.Get(id);

            predmet.Naziv = x.Naziv;
            predmet.Oznaka = x.Oznaka;
            predmet.Godina = x.Godina;

            predmetRepository.Commit();
        }

        public List<Predmet> GetAll()
        {
            return predmetRepository.GetAll();
        }

        public Predmet GetById(int id)
        {
            return predmetRepository.Get(id);
        }
    }
}
