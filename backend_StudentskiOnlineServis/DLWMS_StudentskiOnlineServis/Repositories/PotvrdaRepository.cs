using DLWMS_StudentskiOnlineServis.Data;
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
    public interface IPotvrdaRepository : IRepository<Potvrda>
    {
        PotvrdaGetByParamsResponse GetByParams(PotvrdaGetByParamsRequest request);
        List<SvrhaPotvrde> GetSvrhe();
    }

    public class PotvrdaRepository:Repository<Potvrda>,IPotvrdaRepository
    {
        private readonly DLWMS_baza baza;

        public PotvrdaRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

        public PotvrdaGetByParamsResponse GetByParams(PotvrdaGetByParamsRequest request)
        {
            var potvrde = baza.Potvrda
               .Include(x => x.student)
               .Include(x => x.svrha)
               .AsQueryable();

            if (request.StudentId.HasValue)
            {
                potvrde = potvrde.Where(x => x.studentId == request.StudentId);
            }

            int recordsToSkip = request.PageNumber * request.PageSize;
            
            var result = potvrde;
            if (request.PagedResult)
            {
                result = result.Skip(recordsToSkip).Take(request.PageSize);
            }
           
            return new PotvrdaGetByParamsResponse
            {
                NumberOfRecords = potvrde.Count(),
                Potvrde = result.ToList()
            };
        }

        public List<SvrhaPotvrde> GetSvrhe()
        {
            return baza.SvrhaPotvrde.ToList();
        }

    }
}
