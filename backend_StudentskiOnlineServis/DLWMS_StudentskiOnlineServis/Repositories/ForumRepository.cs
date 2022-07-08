using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Services.Requests;
using System.Collections.Generic;
using System.Linq;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IForumRepository : IRepository<Forum>
    {
        List<Forum> GetByParams(ForumGetByParamsRequest request);
    }

    public class ForumRepository : Repository<Forum>, IForumRepository
    {
        private readonly DLWMS_baza baza;

        public ForumRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

        public List<Forum> GetByParams(ForumGetByParamsRequest request)
        {
            var result = baza.Forum.AsQueryable();

            result= result.Where(x=> x.answererId == request.studentId || x.questionerId == request.studentId);

            return result.ToList();
        }

    }
}
