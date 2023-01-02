using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPEleve
    {
 
        public int Id { get; set; }


 
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Matricule { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }



        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string NomComplet
        {


            get { return Nom + " " + Prenom; }
            private set { }

        }



        public Sexe SexeEleve { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

 
        public string CommuneNaissance { get; set; }


        public string Adresse { get; set; }

        public string PrenomPere { get; set; }

        public string ProfessionPere { get; set; }

        public bool PereVivant { get; set; }

   
        public string NomMere { get; set; }

   
        public string PrenomMere { get; set; }

        public string ProfessionMere { get; set; }

   
        public bool MereVivante { get; set; }

     
        public bool ParentsDivorces { get; set; }

    
        public string NomTuteur { get; set; }

      
        public string PrenomTuteur { get; set; }

        
        public string TelephoneTuteur { get; set; }



       

        public string EmailTuteur { get; set; }

       
        public int NombreFreres { get; set; }

       
        public int NombreSoeurs { get; set; }

      
        public string NomEnArabe { get; set; }

        public string PrenomEnArabe { get; set; }

     
 
        public string MaladiesChroniques { get; set; }

        public string ListMaladies { get; set; }

        public string Medicaments { get; set; }

      
        public bool TransporterAHopital { get; set; }

   
        public string AcuiteVisuelle { get; set; }

        public int GroupesSanguinId { get; set; }

    
        public GroupesSanguin GroupesSanguin { get; set; }

     
        public bool DispenseSport { get; set; }


        public int EPClasseId { get; set; }

        public EPClasse EPClasse { get; set; }


       
        public int ListeEcoleId { get; set; }
        public ListeEcole ListeEcole { get; set; }


        [DataType(DataType.Date)]
        public DateTime DateInscription { get; set; }

 
        public ModePaiement ModeDePaiement { get; set; }

        public int EpTarifTransportId { get; set; }
        public EPTarifTransport EpTarifTransport { get; set; }



        public int Reduction { get; set; }
        
  

        public string Observation { get; set; }




    




        public enum ModePaiement
        {
            Annuel,
            Tranches,
            Mensuel
        }




        public enum Sexe
        {
            Masculin,
            Feminin
        }
    }
}