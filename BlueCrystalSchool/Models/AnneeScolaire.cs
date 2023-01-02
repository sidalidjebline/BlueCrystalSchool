using System;
using System.ComponentModel.DataAnnotations;

namespace BlueCrystalSchool.Models
{
    public class AnneeScolaire
    {
        public int Id { get; set; }

        public string Intitule { get; set; }

       [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime DateDebut { get; set; }

       [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFin { get; set; }   

    }
}