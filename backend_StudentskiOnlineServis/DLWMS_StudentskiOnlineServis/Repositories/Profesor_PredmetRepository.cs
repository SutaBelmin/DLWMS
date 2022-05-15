using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IProfesor_PredmetRepository : IRepository<Profesor_Predmet>
    {
        List<Profesor_Predmet> GetProfesorPredmet(int ProfesorID);
    }

    public class Profesor_PredmetRepository : Repository<Profesor_Predmet>, IProfesor_PredmetRepository
    {
        private readonly DLWMS_baza baza;

        public Profesor_PredmetRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

        public List<Profesor_Predmet> GetProfesorPredmet(int ProfesorID)
        {
           return baza.Profesor_Predmet.Include(x => x.predmet)
                                         .Include(x => x.profesor)
                                         .Where(x => x.profesorId == ProfesorID)
                                         .ToList();
        }
    }
}
