using DLWMS_StudentskiOnlineServis.Data;
using DLWMS_StudentskiOnlineServis.Modul_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_online_servis.Helper
{
    public static class PodesavanjaIndeksa
    {
        public static void Podesi(DLWMS_baza db)
        {
            List<int> Rokovi = new List<int>();
            List<Pitanje> pitanjes = db.Pitanja.ToList();
            foreach (Pitanje _pitanje in pitanjes)
            {
                int l = _pitanje.RokID;
                bool provjera = false;
                foreach (int pr in Rokovi)
                {
                    if (l == pr)
                        provjera = true;
                }
                if (!provjera)
                    Rokovi.Add(l);
            }
            int counter = db.Pitanja.Count();
            foreach (int r in Rokovi)
            {
                int l = db.Pitanja.Where(x => x.RokID == r).Count();
                List<Pitanje> pitanja = db.Pitanja.Where(x => x.RokID == r).ToList();
                for (int i = 1; i <= l; i++)
                    pitanja[i - 1].Indeks = i;

            }
            db.SaveChanges();

        }
    }
}
