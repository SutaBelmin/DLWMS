using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using Microsoft.AspNetCore.Mvc;
using Studentski_online_servis.Helper;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmailController
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
            bool nadjen = _dbContext.Korisnici.Where(x => x.Privatni_email == Email).Count() > 0;
            if (nadjen)
                return "T";
            else
                return "F";
        }
        public class PostavljanjeVerifikacijeVM
        {
            public string mail { get; set; }
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
        [HttpDelete ("{Email}")]
        public void BrisanjeZapisa(string Email)
        {
            Verifikacija v=_dbContext.Verifikacije.Where(x => x.Email == Email).FirstOrDefault();
            _dbContext.Remove(v);
            _dbContext.SaveChanges();
        }
        public class MailVM
        {
            public string To { get; set; }
            public string Subject { get; set; }
            public string Sadrzaj { get; set; }
        }
        [HttpPost]
        public void SendMail([FromBody] MailVM m)
        {
            MailMessage message = new MailMessage("verifikacija.vm@gmail.com", m.To);
            message.Subject = m.Subject;
            message.Body = m.Sadrzaj;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("verifikacija.vm@gmail.com", "Verifikacija.VM");
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
        }
    }
}
