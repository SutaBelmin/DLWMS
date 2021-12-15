using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class Verifikacija
    {
        public int ID { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public Verifikacija(string Token, string Email)
        {
            this.Token = Token;
            this.Email = Email;
        }
    }
}
