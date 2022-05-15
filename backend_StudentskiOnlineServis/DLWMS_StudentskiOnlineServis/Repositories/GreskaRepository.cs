using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IGreskaRepository : IRepository<Greska>
    {

    }
    
    public class GreskaRepository : Repository<Greska>, IGreskaRepository
    {
        public GreskaRepository(DLWMS_baza baza) : base(baza)
        {
        }
    }
}
