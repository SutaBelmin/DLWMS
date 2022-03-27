using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;

namespace DLWMS_StudentskiOnlineServis.Repositories
{


    public interface IForumRepository : IRepository<Forum>
    {

    }

    public class ForumRepository : Repository<Forum>, IForumRepository
    {
        private readonly DLWMS_baza baza;

        public ForumRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

    }
}
