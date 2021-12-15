using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DLWMS_StudentskiOnlineServis.Modul_1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FakultetController
    {
        private DLWMS_baza _dbContext;
        public FakultetController(DLWMS_baza dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("{Naziv},{Grad}")]
        public string DodajFakultet(string Naziv, string Grad)
        {
            Fakultet x = new Fakultet(Naziv, Grad);
            _dbContext.Fakulteti.Add(x);
            _dbContext.SaveChanges();
            return $"Fakultet uspjesno dodat";
        }
        [HttpGet]
        public object GetFakulteti(string Naziv)
        {
            return _dbContext.Fakulteti.Where(x =>Naziv==null 
            || x.Naziv.ToLower().StartsWith(Naziv) 
            || x.Grad.ToLower().StartsWith(Naziv)).ToList();
        }
    }
}
