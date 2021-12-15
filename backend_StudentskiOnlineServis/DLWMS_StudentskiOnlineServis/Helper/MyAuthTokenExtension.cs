using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using DLWMS_StudentskiOnlineServis.Data;

namespace Studentski_online_servis.Helper
{
    public static class MyAuthTokenExtension
    {

        public static AutentifikacijaToken GetKorisnikOfAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            DLWMS_baza db = httpContext.RequestServices.GetService<DLWMS_baza>();
            AutentifikacijaToken tokenNalog= db.AutentifikacijaToken.Where(x => token != null && x.Vrijednost == token).SingleOrDefault();
            return tokenNalog;
        }

        //public static KorisnickiNalog GetKorisnikOfAuthToken(string token)
        //{
        //    //KorisnickiNalog korisnickiNalog = dlwms.AutentifikacijaToken.Where(x => token != null && x.Vrijednost == token).Select(s => s.KorisnickiNalog).SingleOrDefault();
        //    //return korisnickiNalog;
        //}

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["Token"];
            return token;
        }
    }
}
