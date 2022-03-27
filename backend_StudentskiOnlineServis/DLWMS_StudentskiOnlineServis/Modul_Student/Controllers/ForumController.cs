using DLWMS_StudentskiOnlineServis.Modul_Student.ViewModels;
using DLWMS_StudentskiOnlineServis.Services;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using Microsoft.AspNetCore.Mvc;
using Studentski_online_servis.Helper;

namespace DLWMS_StudentskiOnlineServis.Modul_Student.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ForumController : ControllerBase
    {
        private readonly IForumService forumService;

        public ForumController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var forum = forumService.GetForums();

            return Ok(forum);
        }

        [HttpPost]
        public ActionResult AddPitanje(AddPitanjeVM x)
        {
            forumService.AddPitanje(new AddPitanjeServiceRequest
            {
                Pitanje = x.Pitanje,
                QuestionerId = HttpContext.GetLoginInfo().korisnickiNalog.student.ID
            });

            return Ok();
        }


        [HttpPost("{id}")]
        public ActionResult AddOdgovor(int id, AddOdgovorVM x)
        {
            forumService.AddOdgovor(new AddOdgovorServiceRequest
            {
                Id = id,
                AnswererId = HttpContext.GetLoginInfo().korisnickiNalog.student.ID,
                Odgovor = x.Odgovor
            });

            return Ok();
        }
    }
}
