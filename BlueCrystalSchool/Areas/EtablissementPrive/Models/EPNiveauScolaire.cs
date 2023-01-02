

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPNiveauScolaire
    {
        public int Id { get; set; }

        public string Niveau { get; set; }

        public int PalierId { get; set; }

        public Palier Palier { get; set; }  
        public int FiliereId { get; set; }

        public Filiere Filiere { get; set; }

        public int FraisInscription { get; set; }

        [DisplayName("Paiement Annuel")]
        public int TarifPaiementAnnuel { get; set; }

        public int TarifPaiementTroisTranches { get; set; }

        public int TarifPaiementMensuel { get; set; }









    }
}