﻿using DLWMS_StudentskiOnlineServis.Modul_1.ViewModels;
using DLWMS_StudentskiOnlineServis.Modul_Referent.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.Models;
using DLWMS_StudentskiOnlineServis.Modul_Student.Modul_Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Modul_1.Models
{
    public class KorisnickiNalog
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string ?BrojTelefona { get; set; }
        public bool isTwoWayAuth { get; set; } = false;

        [ForeignKey(nameof(FakultetID))]
        public Fakultet Fakultet { get; set; }
        public int FakultetID { get; set; }
        public string PrivatniEmail { get; set; }
        public string FakultetEmail { get; set; }
        [JsonIgnore]
        public Profesor Profesor => this as Profesor;
        public bool isProfesor => Profesor != null;

        //public bool isAdmin { get; set; }

        [JsonIgnore]
        public Student student => this as Student;
        public bool isStudent => student != null;

        [JsonIgnore]
        public Referent referent => this as Referent;
        public bool isReferent => referent != null;

        [JsonIgnore]
        public Admin admin => this as Admin;
        public bool isAdmin => admin != null;

    }
}
