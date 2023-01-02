using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Models
{
    public class CSEnseignant
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }




        public DateTime DateNaissance { get; set; }

        public string CommuneNaissance { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }

        public virtual IList<CSMatiere> CSMatieres { get; set; }

     


        public int? PalierId { get; set; }

        public Palier Palier { get; set; }


        public bool CoursSoutien { get; set; }


        public bool CoursParticuliers { get; set; }



    
       

    }
}