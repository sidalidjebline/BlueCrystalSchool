using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPPointageEleve
    {
        public int Id { get; set; }


        public int AnneeScolaireId { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }


        public int EPEleveId { get; set; }

      //  public EPEleve EPEleve { get; set; }


        public DateTime DatePointage { get; set; }

        public bool Presence { get; set; }

        public string Justification { get; set; }


    }
}