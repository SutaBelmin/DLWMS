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
            MailMessage message = new MailMessage("mverifikacija@gmail.com", m.To);
            message.Subject = m.Subject;
            message.Body = m.Sadrzaj;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("mverifikacija@gmail.com", "Verifikacija.VM");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
    }
}
