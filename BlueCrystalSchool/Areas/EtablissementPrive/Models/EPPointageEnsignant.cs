using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPPointageEnsignant
    {
        public int Id { get; set; }


        public int AnneeScolaireId { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }



        public int EPEnseignantId { get; set; }
        public EPEnseignant EPEnseignant { get; set; }



        public DateTime DatePointage { get; set; }

        public int NombreSeances { get; set; }






  


    }
}