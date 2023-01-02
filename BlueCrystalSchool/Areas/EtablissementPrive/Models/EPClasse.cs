using System.Collections.Generic;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Models
{
    public class EPClasse
    {
        public int Id { get; set; }

        public int EPNiveauScolaireId { get; set; }

        public EPNiveauScolaire EPNiveauScolaire { get; set; }

        public string NomClasse { get; set; } /** Exemple: 1AS1, 1As20 **/

        public string NomSalle { get; set; }

        public int NombreMaxEleves { get; set; }

        public int NombrePlacesDisponibles { get; set; }


        public IList<EPEnseignant> EPEnseignants { get; set; }
        public IList<EPEleve> EPEleves { get; set; }
    }
}