using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IUspjehRepository : IRepository<Uspjeh>
    {
        List<Uspjeh> GetListUspjeh(int studentId);
    }

    public class UspjehRepository : Repository<Uspjeh>, IUspjehRepository
    {
        private readonly DLWMS_baza baza;

        public UspjehRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

        public List<Uspjeh> GetListUspjeh(int studentId)
        {
            var studId = studentId;
            var uspjeh = baza.Uspjeh
                .Include(x => x.student_predmet)
                .ThenInclude(x => x.predmet)
                .Where(x => x.student_predmet.studentId == studId)
                .ToList();

            return uspjeh;
        }
    }
}
