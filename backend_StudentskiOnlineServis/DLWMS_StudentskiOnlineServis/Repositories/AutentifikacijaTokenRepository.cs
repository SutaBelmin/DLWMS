using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IAutentifikacijaTokenRepository : IRepository<AutentifikacijaToken>
    {
        List<AutentifikacijaToken> GetByStudentId(int id);
    }

    public class AutentifikacijaTokenRepository : Repository<AutentifikacijaToken>, IAutentifikacijaTokenRepository
    {
        private readonly DLWMS_baza baza;

        public AutentifikacijaTokenRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

        public List<AutentifikacijaToken> GetByStudentId(int id)
        {
            var result = baza.AutentifikacijaToken
                .Include(x => x.KorisnickiNalog)
                .Where(x => x.KorisnickiNalog.ID == id)
                .ToList();

            return result;
        }
    }
}
