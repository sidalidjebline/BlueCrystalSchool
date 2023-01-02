using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Models
{
    public class CSHistoPaiementEleve
    {
        public int Id { get; set; }


        //public int CSEleveId { get; set; }
        //public CSEleve CSEleve { get; set; }

        public int Montant { get; set; }

        public DateTime DateTime { get; set; }



    }
}