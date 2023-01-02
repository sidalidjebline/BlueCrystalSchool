using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Models
{
    public class CSTarificationEnseignant
    {
        public int Id { get; set; }

        public string TypeTarification { get; set; }

        public float Tarif { get; set; }
    }
}