

namespace BlueCrystalSchool.Models
{
    public class Commune
    {
        public int Id { get; set; }

        public string NomCommune { get; set; }

        public int WilayaId { get; set; }

        public Wilaya Wilaya { get; set; }

    }
}