using System;
using System.ComponentModel.DataAnnotations;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPPaiementEleve
    {
        public int Id { get; set; }

        public int EPEleveId { get; set; }

        public EPEleve EPEleve { get; set; }

        [Required]
        public float Montant { get; set; }

        [Required]
        public float Reste { get; set; }

        public int AnneeScolaireId { get; set; }

        public AnneeScolaire AnneeScolaire { get; set; }


        [DataType(DataType.Date)]
        public DateTime DateVersement { get; set; }


        [DataType(DataType.Date)]
        public DateTime DateProchainPaiement { get; set; }

        public string Observations { get; set; }


    }
}