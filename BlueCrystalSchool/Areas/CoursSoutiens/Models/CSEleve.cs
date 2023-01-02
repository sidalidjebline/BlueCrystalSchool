using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlueCrystalSchool.Areas.EtablissementPrive.Controllers;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Models
{
    public class CSEleve
    {
        public int Id { get; set; }


        //[StringLength(15)]
        //[Index(IsUnique = true)]
        //[Required]
        //public string Matricule { get; set; }

        [Required] public string Nom { get; set; }

        [Required] public string Prenom { get; set; }


        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public string NomComplet
        //{


        //    get { return Nom + " " + Prenom; }
        //    private set { }

        //}


        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }


        [Required]
        public string CommuneNaissance { get; set; }


        public int Reduction { get; set; }


        public string Observation { get; set; }

        public int CSNiveauScolaireId { get; set; }
        public CSNiveauScolaire CSNiveauScolaire { get; set; }

        public int ListeEcoleId { get; set; }
        public ListeEcole ListeEcole { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Solde { get; set; }
        //public bool CoursSoutien { get; set; }
        //public bool CoursParticuliers { get; set; }

        public IList<CSMatiere> CSMatieres { get; set; }

        public int? NombreMatieres { get; set; }
        public IList<CSGroupe> CsGroupes { get; set; }

        
    }
}