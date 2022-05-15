using DLWMS_StudentskiOnlineServis.Exceptions;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IPotvrdaService
    {
        List<Potvrda> GetByParams(int? studentId);
        void AddPotvrdu(AddPotvrdaRequest x);
        List<SvrhaPotvrde> GetSvrhe();
        void IzdajPotvrdu(int id, int referentId);
    }

    public class PotvrdaService: IPotvrdaService
    {
        private readonly IPotvrdaRepository potvrdaRepository;

        public PotvrdaService(IPotvrdaRepository potvrdaRepository)
        {
            this.potvrdaRepository = potvrdaRepository;
        }
        public List<Potvrda> GetByParams(int? studentId)
        {
           return potvrdaRepository.GetByParams(studentId);
        }

        public void AddPotvrdu(AddPotvrdaRequest x)
        {
            potvrdaRepository.Add(new Potvrda
            {
                studentId = x.studentId,
                svrhaId = x.svrhaId,
                Opis = x.Opis
            });
            potvrdaRepository.Commit();
        }

        public List<SvrhaPotvrde> GetSvrhe()
        {
            return potvrdaRepository.GetSvrhe();
        }

        public void IzdajPotvrdu(int id, int referentId)
        {
            var potvrda = potvrdaRepository.Get(id);
            if(potvrda == null)
            {
                throw new NotFoundException("Potvrda not found.");
            }
            if (potvrda.Izdata)
            {
                throw new ValidationException("Potvrda already signed.");
            }
            potvrda.Izdata = true;
            potvrda.referentId = referentId;
            potvrda.datum_izdavanja = DateTime.Now;
            potvrdaRepository.Update(potvrda);
            potvrdaRepository.Commit();
        }
    }
}
