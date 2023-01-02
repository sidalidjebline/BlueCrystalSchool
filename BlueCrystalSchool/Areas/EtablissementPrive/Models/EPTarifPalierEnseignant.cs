using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPTarifPalierEnseignant
    {
        public int Id { get; set; }
        public int PalierId { get; set; }

        public Palier Palier { get; set; }

        public int TarifParHeure { get; set; }

    }
}