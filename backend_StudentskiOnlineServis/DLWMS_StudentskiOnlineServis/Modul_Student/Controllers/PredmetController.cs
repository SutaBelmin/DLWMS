using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class PredmetController : ControllerBase
    {
        private readonly DLWMS_baza _baza;

        public PredmetController(DLWMS_baza baza)
        {
            this._baza = baza;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var predemti = _baza.Predmet.ToList();

            return Ok(predemti);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var predemti = _baza.Predmet.FirstOrDefault(x => x.Id == id);

            return Ok(predemti);
        }

        [HttpPost]
        public ActionResult AddPredmet(AddEditPredmetVM x)
        {
            var predmet = new Predmet();

            predmet.Naziv = x.Naziv;
            predmet.Oznaka = x.Oznaka;
            predmet.Godina = x.Godina;

            _baza.Predmet.Add(predmet);
            _baza.SaveChanges();

            return Ok();   
        }

        [HttpPost("{id}")]
        public ActionResult EditPredmet(int id, AddEditPredmetVM x)
        {
            var predmet = _baza.Predmet.Find(id);

            predmet.Naziv = x.Naziv;
            predmet.Oznaka = x.Oznaka;
            predmet.Godina = x.Godina;

            _baza.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var predmet = _baza.Predmet
                 .FirstOrDefault(x => x.Id == id);

            if (predmet == null)
                return BadRequest("pogresan ID");

            _baza.Remove(predmet);

            _baza.SaveChanges();
            return Ok(predmet);
        }
    }
}
