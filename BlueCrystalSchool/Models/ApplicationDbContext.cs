using System.Data.Entity;
using System.Security.AccessControl;
using BlueCrystalSchool.Areas.CoursSoutiens.Models;
using BlueCrystalSchool.Areas.EtablissementPrive.Controllers;
using BlueCrystalSchool.Areas.EtablissementPrive.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlueCrystalSchool.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<AnneeScolaire> AnneeScolaires { get; set; }

        public DbSet<Wilaya> Wilayas { get; set; }

        public DbSet<Commune> Communes { get; set; }

        public DbSet<Palier> Paliers { get; set; }

        public DbSet<Filiere> Filieres { get; set; }

        public DbSet<GroupesSanguin> GroupesSanguins { get; set; }

        public DbSet<ListeEcole> ListeEcoles { get; set; }

        public DbSet<EPTarifTransport> EpTarifTransports { get; set; }

        public DbSet<EPNiveauScolaire> EpNiveauScolaires { get; set; }




        public DbSet<CSNiveauScolaire> CsNiveauScolaires { get; set; }

        public DbSet<CSNombreMatiere> CSNombreMatieres { get;  set; }

        public DbSet<CSTarifCoursParticulier> CsTarifCoursParticuliers { get; set; }

        public DbSet<CSTarifCoursSoutien> CsTarifCoursSoutiens { get; set; }




        public DbSet<EPTarifPalierEnseignant> EpTarifPalierEnseignants { get; set; }

        public DbSet<EPClasse> EpClasses { get; set; }

        public DbSet<EPMatiere> EpMatieres { get; set; }

        public DbSet<EPEleve> EpEleves { get; set; }
        public DbSet<EPEnseignant> EpEnseignants { get; set; }


        public DbSet<CSTarificationEnseignant> CsTarificationEnseignants { get; set; }

       public DbSet<EPPaiementEleve> EpPaiementEleves { get; set; }


        public DbSet<CSMatiere> CsMatieres { get; set; }

        public DbSet<CSEnseignant> CsEnseignants { get; set; }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<EPModePaiement> EpModePaiements { get; set; }

        public DbSet<CSEleve> CsEleves { get; set; }
 

      public DbSet<CSGroupe> CSGroupes { get; set; }

       
    }
}