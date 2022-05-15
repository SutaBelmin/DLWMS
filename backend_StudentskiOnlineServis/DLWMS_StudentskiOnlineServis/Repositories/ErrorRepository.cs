using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IErrorRepository : IRepository<Error>
    {

    }
    public class ErrorRepository : Repository<Error>, IErrorRepository
    {
        private readonly DLWMS_baza baza;

        public ErrorRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }
    }
}
