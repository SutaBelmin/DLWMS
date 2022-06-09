using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Modul_1.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentski_online_servis.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Studentski_online_servis.Helper.MyAuthTokenExtension;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaLoginController : ControllerBase
    {
        private DLWMS_baza _dbContext;
        public AutentifikacijaLoginController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] AutentifikacijaLoginPostVM x)
        {
            KorisnickiNalog k = _dbContext.KorisnickiNalog.Where(s => s.KorisnickoIme == x.Username && s.Lozinka == x.Password && s.Fakultet.ID == x.Fakultet_S).SingleOrDefault();
            if (k == null)
                return new LoginInformacije(null);

            string tokenString = TokenGenerator.Generate(15);
            var noviToken = new AutentifikacijaToken()
            {
                IP_Adresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Vrijednost = tokenString,
                KorisnickiNalogId = k.ID,
                VrijemeEvidentiranja = DateTime.Now
            };
            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();
            return new LoginInformacije(noviToken);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            AutentifikacijaToken k = HttpContext.GetAuthToken();
            if (k != null)
            {
                _dbContext.Remove(k);
                _dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
