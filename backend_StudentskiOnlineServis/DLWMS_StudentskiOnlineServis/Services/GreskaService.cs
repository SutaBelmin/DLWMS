using DLWMS_StudentskiOnlineServis.Exceptions;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IGreskaService
    {
        void PrijavaGreske(AddGreskaRequest x);
        List<Greska> GetAll();
    }

    public class GreskaService : IGreskaService
    {
        private readonly IGreskaRepository greskaRepository;

        public GreskaService(IGreskaRepository greskaRepository)
        {
            this.greskaRepository = greskaRepository;
        }

        public List<Greska> GetAll()
        {
            return greskaRepository.GetAll();
        }

        public void PrijavaGreske(AddGreskaRequest x)
        {
            if (string.IsNullOrWhiteSpace(x.Opis))
            {
                throw new ValidationException("Opis is required.");
            }
            var greska = new Greska();

            greska.Opis = x.Opis;
            greska.Datum_prijave = DateTime.Now;

            greskaRepository.Add(greska);
            greskaRepository.Commit();
        }
    }
}
