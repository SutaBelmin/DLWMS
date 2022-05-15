using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IStudent_PredmetRepository : IRepository<Student_Predmet>
    {
        List<Student_Predmet> GetStudentPredmetPodaci(int predmetID);
    }

    public class Student_PredmetRepository : Repository<Student_Predmet>, IStudent_PredmetRepository
    {
        private readonly DLWMS_baza baza;

        public Student_PredmetRepository(DLWMS_baza baza) : base(baza)
        {
            this.baza = baza;
        }

        public List<Student_Predmet> GetStudentPredmetPodaci(int predmetID)
        {
            return baza.Student_Predmet.Include(x=>x.predmet)
                                        .Include(x=>x.student)
                                        .Where(x => x.predmetId == predmetID && x.isPolozio==false)
                                        .ToList();
        }
    }
}
