using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IUspjehService
    {
        List<Uspjeh> GetListUspjeh(int studentId);

        void AddOcjenu(AddOcjenaRequest x);
    }

    public class UspjehService : IUspjehService
    {
        private readonly IUspjehRepository uspjehRepository;

        public UspjehService(IUspjehRepository uspjehRepository)
        {
            this.uspjehRepository = uspjehRepository;
        }

        public void AddOcjenu(AddOcjenaRequest x)
        {
            var uspjeh = new Uspjeh();

            uspjeh.student_predmetId = x.student_predmetId;
            uspjeh.profesor_predmetId = x.profesor_predmetId;
            uspjeh.ocjena = x.ocjena;
            uspjeh.datum_upisa = x.datum_upisa;

            uspjehRepository.Add(uspjeh);
            uspjehRepository.Commit();
        }

        public List<Uspjeh> GetListUspjeh(int studentId)
        {
            return uspjehRepository.GetListUspjeh(studentId);
        }
    }
}
