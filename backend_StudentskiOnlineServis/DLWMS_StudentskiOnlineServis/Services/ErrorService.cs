using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IErrorService
    {
        void AddError(AddErrorRequest request);
    }
    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository errorRepository;

        public ErrorService(IErrorRepository errorRepository)
        {
            this.errorRepository = errorRepository;
        }

        public void AddError(AddErrorRequest request)
        {
            var err = new Error()
            {
                KorisnickiNalogId = request.KorisnickiNalogId,
                Message = request.Message,
                Method = request.Method,
                Date = DateTime.Now,
                Url = request.Url
            };
            errorRepository.Add(err);
            errorRepository.Commit();
        }
    }
}
