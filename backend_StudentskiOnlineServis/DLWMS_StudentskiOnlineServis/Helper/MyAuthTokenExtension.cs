using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Data;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Studentski_online_servis.Helper
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }

            [JsonIgnore]
            public KorisnickiNalog korisnickiNalog => autentifikacijaToken?.KorisnickiNalog;
            public AutentifikacijaToken autentifikacijaToken { get; set; }
            public bool isLogiran => korisnickiNalog != null;
            public bool isPermisijaProfesor => isLogiran && (korisnickiNalog.Profesor != null || korisnickiNalog.isAdmin);
            public bool isPermisijaAdmin => isLogiran && korisnickiNalog.isAdmin;
        }
        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }
        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            DLWMS_baza db = httpContext.RequestServices.GetService<DLWMS_baza>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
                .Include(s => s.KorisnickiNalog)
                .SingleOrDefault(x => token != null && x.Vrijednost == token);

            return korisnickiNalog;
        }

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["Token"];
            return token;
        }
    }
}
