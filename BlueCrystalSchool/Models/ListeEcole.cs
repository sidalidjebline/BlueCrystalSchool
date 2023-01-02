namespace BlueCrystalSchool.Models
{
    public class ListeEcole
    {
        public int Id { get; set; }

        public string NomEtablissemnt { get; set; }

        public string Adresse { get; set; }

        public string NumeroTelephone { get; set; }

        public TypeEcole Typeecole { get; set; }




        public enum TypeEcole
        {
            Publique,
            Privé
        }


    }
}