using DLWMS_StudentskiOnlineServis.Services;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using Microsoft.AspNetCore.Mvc;
using Studentski_online_servis.Helper;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PotvrdaController:ControllerBase
    {
        private readonly IPotvrdaService potvrdaService;

        public PotvrdaController(IPotvrdaService potvrdaService)
        {
            this.potvrdaService = potvrdaService;
        }


        [HttpGet]
        public IActionResult GetAll([FromQuery] PotvrdaGetByParamsRequest request)
        {
            var result = potvrdaService.GetByParams(request);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddPotvrdu(AddPotvrdaRequest x)
        {
            x.studentId = HttpContext.GetLoginInfo().korisnickiNalog.student.ID;
            potvrdaService.AddPotvrdu(x);

            return Ok();
        }

        [HttpPost("{id}")]
        public ActionResult IzdajPotvrdu(int id)
        {
            var referentId = HttpContext.GetLoginInfo().korisnickiNalog.referent.ID;
            potvrdaService.IzdajPotvrdu(id, referentId);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetSvrhe()
        {
            return Ok(potvrdaService.GetSvrhe());

        }


    }
}
