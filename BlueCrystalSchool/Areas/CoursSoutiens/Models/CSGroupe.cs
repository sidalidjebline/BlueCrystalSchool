using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Models
{
    public class CSGroupe
    {
        public int Id { get; set; }

        public string NomGroupe { get; set; }

        public IList<CSEleve> CsEleves { get; set; }
        public int CSMatiereId { get; set; }
        public CSMatiere CSMatiere { get; set; }

        public int CSEnseignantId { get; set; }

        public CSEnseignant CSEnseignant { get; set; }


        public int CsNiveauScolaireId { get; set; }   
        public CSNiveauScolaire CsNiveauScolaire { get; set; }
    }
}