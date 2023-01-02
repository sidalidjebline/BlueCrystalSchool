using System.Collections.Generic;


namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPMatiere
    {
        public int Id { get; set; }

        public string NomMatiere { get; set; }

       public IList<EPEnseignant> EPEnseignants { get; set; }
    }
}