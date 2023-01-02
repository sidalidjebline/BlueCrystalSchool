using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Models
{
    public class CSMatiere
    {
        public int Id { get; set; }

        public string NomMatiere { get; set; }
    
        public bool IsSelected { get; set; }
        public IList<CSEnseignant> CSEnseignants { get; set; }

        public IList<CSEleve> CSEleves { get; set; }
    }
}