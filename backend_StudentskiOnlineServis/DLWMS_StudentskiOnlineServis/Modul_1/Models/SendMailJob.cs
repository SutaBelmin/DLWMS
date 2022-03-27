using DLWMS_StudentskiOnlineServis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quartz;
using Studentski_online_servis.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class SendMailJob : IJob
    {
        private readonly DLWMS_baza _dbContext;
        private readonly ILogger logger;


        public SendMailJob(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task Execute(IJobExecutionContext context)
        {
            var rokovi = _dbContext.Rokovi.Include(x=>x.Predmet).Where(x => x.DatumOdrzavanja.DayOfYear - DateTime.Now.DayOfYear < 3).ToList();
            var studenti = _dbContext.Studenti.ToList();
            foreach (var r in rokovi)
            {
                foreach (var s in studenti)
                {
                    PodesavanjaIndeksa._SendMail(s.PrivatniEmail, $"NAPOMENA ZA ISPIT IZ PREDMETA {r.Predmet.Naziv}", $"{r.DatumOdrzavanja}");
                }
            }
        }
    }
}
