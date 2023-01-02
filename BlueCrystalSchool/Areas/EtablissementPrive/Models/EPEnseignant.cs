using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPEnseignant
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

      
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public string NomComplet
        //{


        //    get { return Nom + " " + Prenom; }
        //    private set { }
        //}

        public DateTime DateNaissance { get; set; }

        public string CommuneNaissance { get; set; }

        public int PalierId { get; set; }
        public Palier Palier { get; set; }

        //public int EPMatiereId { get; set; }

        //public  EPMatiere EPMatiere { get; set; }

     public IList<EPMatiere> EPMatieres { get; set; }
        public IList<EPClasse> EPClasses { get; set; }

        public bool DonneCoursSoutien { get; set; }

        public bool DonneCoursParticulier { get; set; }
    }
}