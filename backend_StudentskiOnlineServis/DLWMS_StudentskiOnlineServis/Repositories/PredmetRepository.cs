using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IPredmetRepository : IRepository<Predmet>
    {
    }

    public class PredmetRepository : Repository<Predmet> , IPredmetRepository
    {
        private readonly DLWMS_baza baza;

        public PredmetRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }
    }
}
