using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IPotvrdaRepository : IRepository<Potvrda>
    {
        List<Potvrda> GetByParams(int? studentId);
        List<SvrhaPotvrde> GetSvrhe();
    }

    public class PotvrdaRepository:Repository<Potvrda>,IPotvrdaRepository
    {
        private readonly DLWMS_baza baza;

        public PotvrdaRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

        public List<Potvrda> GetByParams(int? studentId)
        {
            var potvrde = baza.Potvrda
               .Include(x => x.student)
               .Include(x => x.svrha)
               .AsQueryable();

            if (studentId.HasValue)
            {
                potvrde = potvrde.Where(x => x.studentId == studentId);
            }

            return potvrde.ToList();
        }

        public List<SvrhaPotvrde> GetSvrhe()
        {
            return baza.SvrhaPotvrde.ToList();
        }

    }
}
