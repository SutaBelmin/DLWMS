using DLWMS_StudentskiOnlineServis.Exceptions;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Repositories;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System.Collections.Generic;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IForumService
    {
        List<Forum> GetForums();
        void AddPitanje(AddPitanjeServiceRequest x);
        void AddOdgovor(AddOdgovorServiceRequest x);
    }

    public class ForumService : IForumService
    {
        private readonly IForumRepository forumRepository;

        public ForumService(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        public void AddOdgovor(AddOdgovorServiceRequest x)
        {
            var forum = forumRepository.Get(x.Id);
           
            if (forum == null)
            {
                throw new NotFoundException("Forum not found.");
            }

            forum.Odgovor = x.Odgovor;
            forum.answererId = x.AnswererId;

            forumRepository.Update(forum);
            forumRepository.Commit();
        }

        public void AddPitanje(AddPitanjeServiceRequest x)
        {
            var forum = new Forum
            {
                Pitanje = x.Pitanje,
                questionerId = x.QuestionerId
            };

            forumRepository.Add(forum);
            forumRepository.Commit();
        }

        public List<Forum> GetForums()
        {
            return forumRepository.GetAll();
        }
    }
}
