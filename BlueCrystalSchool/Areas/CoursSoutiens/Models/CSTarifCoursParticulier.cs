using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Models
{
    public class CSTarifCoursParticulier
    {
        public int Id { get; set; }









        public int CSNiveauScolaireId { get; set; }

        public CSNiveauScolaire CSNiveauScolaire { get; set; }


        public int Tarif { get; set; }
    }
}