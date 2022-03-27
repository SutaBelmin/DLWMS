using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Credentials = Vonage.Request.Credentials;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ChatController : Controller
    {
        private DLWMS_baza _dbContext;
        public ChatController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }
        public class ChatVM
        {
            public string sadrzaj { get; set; }
            public int korisnik1ID { get; set; }
            public int korisnik2ID { get; set; }
            public DateTime date { get; set; }
        }
        [HttpPost]
        public ActionResult SendMessage([FromBody] ChatVM x)
        {
            var korisnik1 = _dbContext.KorisnickiNalog.Where(a => a.ID == x.korisnik1ID).FirstOrDefault();
            var korisnik2 = _dbContext.KorisnickiNalog.Where(a => a.ID == x.korisnik2ID).FirstOrDefault();
            if (x.sadrzaj == "string" || x.sadrzaj == null)
                return BadRequest("Sadrzaj nije validan");
            if (korisnik1 == null || korisnik2 == null)
                return BadRequest("Korisnik-1 || Korisnik-2 -> NE POSTOJI");
            CHAT poruka = new CHAT()
            {
                sadrzaj = x.sadrzaj,
                korisnik1_ID = x.korisnik1ID,
                korisnik2_ID = x.korisnik2ID,
                datumPoruke = x.date
            };
            _dbContext.Add(poruka);
            _dbContext.SaveChanges();
            //var credentials = Credentials.FromApiKeyAndSecret(
            // "fe81180b",
            //"ZrFpIHe0tZj8aNcP"
            //);

            //var VonageClient = new VonageClient(credentials);

            //var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            //{
            //    To = "38762610068",
            //    From = "Vonage APIs",
            //    Text = "A text message sent using the Vonage SMS API"
            //    //To = "$"{Broj telefona od korisnika}"" ///////////// FREE VERZIJA, NE RADE PORUKE KOJE MI ZELIMO
            //    //From = "CHAT - STUDENTSKI ONLINE SERVIS"
            //    //TEXT= $"Dobili ste poruku od {korisnik1.korisnickoime}"
            //});
            return Ok(poruka);
        }

        [HttpGet]
        public object GetPoruke(int korisnikID1, int korisnikID2)
        {
            var provjera1 = _dbContext.KorisnickiNalog.Where(x => x.ID == korisnikID1).FirstOrDefault();
            var provjera2 = _dbContext.KorisnickiNalog.Where(x => x.ID == korisnikID2).FirstOrDefault();

            if (provjera1 == null || provjera2 == null)
                return BadRequest("Korisnik ne postoji");
            return _dbContext.Poruke
                .Include(x => x.korisnik1)
                .Include(x => x.korisnik2)
                .Where(x => (x.korisnik1_ID == korisnikID1 || x.korisnik2_ID == korisnikID1) && (x.korisnik1_ID == korisnikID2 || x.korisnik2_ID == korisnikID2)).ToList();
        }
    }
}
