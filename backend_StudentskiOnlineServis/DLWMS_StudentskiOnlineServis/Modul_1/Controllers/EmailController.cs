using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Studentski_online_servis.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Studentski_online_servis.IB190057.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmailController : ControllerBase
    {
        private DLWMS_baza _dbContext;
        public EmailController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public string Get(string Email)
        {
            if (string.IsNullOrEmpty(Email))
                return "F";
            bool nadjen = _dbContext.KorisnickiNalog.Where(x => x.PrivatniEmail == Email).Count() > 0;
            if (nadjen)
                return "T";
            else
                return "F";
        }

        [HttpPost]
        public string GenerisiToken([FromBody] PostavljanjeVerifikacijeVM pv)
        {
            string token = TokenGenerator.Generate(6);
            Verifikacija x = new Verifikacija(token, pv.mail);
            _dbContext.Add(x);
            _dbContext.SaveChanges();
            return token;
        }
        [HttpDelete("{Email}")]
        public IActionResult BrisanjeZapisa(string Email)
        {
            List<Verifikacija> v = _dbContext.Verifikacije.Where(x => x.Email == Email).ToList();
            foreach (Verifikacija i in v)
            {
                _dbContext.Remove(i);
            }
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult SendMail([FromBody] MailVM m)
        {
            PodesavanjaIndeksa._SendMail(m.To, m.Subject, m.Sadrzaj);
            return Ok();
        }
    }
}
