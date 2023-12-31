﻿using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {
        private DLWMS_baza dLWMS_Db;
        private VrstaKorisnika vrsta;
        private string _vrsta;
        private VrstaKorisnika NovaVrsta;
        public KorisnikController(DLWMS_baza dbContext)
        {
            dLWMS_Db = dbContext;
        }
        public class KorisnikVM
        {
            public string Ime { get; set; }
            public string KorisnickoIme { get; set; }
            public string Prezime { get; set; }
            public string Password { get; set; }
            public string Vrsta_Korisnika { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public DateTime DatumPrijave { get; set; }
        }
        [HttpPost]
        public string DodajKorisnika([FromBody] KorisnikVM NoviKorisnik)
        {
            if (NoviKorisnik.Vrsta_Korisnika.CompareTo("Profesor") == 0 || NoviKorisnik.Vrsta_Korisnika.CompareTo("profesor") == 0)
            {
                vrsta = VrstaKorisnika.Profesor;
                _vrsta = "Profesor";
            }
            else if (NoviKorisnik.Vrsta_Korisnika.CompareTo("Student") == 0 || NoviKorisnik.Vrsta_Korisnika.CompareTo("student") == 0)
            {
                vrsta = VrstaKorisnika.Student;
                _vrsta = "Student";
            }
            else if (NoviKorisnik.Vrsta_Korisnika.CompareTo("Referent") == 0 || NoviKorisnik.Vrsta_Korisnika.CompareTo("referent") == 0)
            {
                vrsta = VrstaKorisnika.Referent;
                _vrsta = "Referent";
            }
            Korisnik noviKorisnik = new Korisnik();
            noviKorisnik.Ime = NoviKorisnik.Ime;
            noviKorisnik.Prezime = NoviKorisnik.Prezime;
            noviKorisnik.Vrsta_Korisnika = vrsta;
            noviKorisnik.DatumRodjenja = NoviKorisnik.DatumRodjenja;
            noviKorisnik.DatumPrijave = NoviKorisnik.DatumPrijave;
            noviKorisnik.KorisnickoIme = NoviKorisnik.KorisnickoIme;
            noviKorisnik.Lozinka = NoviKorisnik.Password;
            noviKorisnik.FakultetID = 1;
            dLWMS_Db.Korisnici.Add(noviKorisnik);
            dLWMS_Db.SaveChanges();
            return $"{_vrsta} uspjesno dodat";
        }
        [HttpGet]
        public object GetKorisnike(int KorisnikID)
        {
            return dLWMS_Db.KorisnickiNalog.Where(x=>x.ID!=KorisnikID).ToList();
        }
    }

}
