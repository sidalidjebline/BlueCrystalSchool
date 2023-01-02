using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Models
{
    public class CSNiveauScolaire
    {
        public int Id { get; set; }

        public string Niveau { get; set; }

        public int PalierId { get; set; }

        public Palier Palier { get; set; }
        public int FiliereId { get; set; }

        public Filiere Filiere { get; set; }
    }
}