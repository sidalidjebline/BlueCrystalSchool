namespace BlueCrystalSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnneeScolaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Intitule = c.String(),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Communes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomCommune = c.String(),
                        WilayaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wilayas", t => t.WilayaId, cascadeDelete: true)
                .Index(t => t.WilayaId);
            
            CreateTable(
                "dbo.Wilayas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomWilaya = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CSEleves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        GenderId = c.Int(nullable: false),
                        DateNaissance = c.DateTime(nullable: false),
                        CommuneNaissance = c.String(nullable: false),
                        Reduction = c.Int(nullable: false),
                        Observation = c.String(),
                        CSNiveauScolaireId = c.Int(nullable: false),
                        ListeEcoleId = c.Int(nullable: false),
                        Solde = c.Double(),
                        NombreMatieres = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CSNiveauScolaires", t => t.CSNiveauScolaireId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.ListeEcoles", t => t.ListeEcoleId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.CSNiveauScolaireId)
                .Index(t => t.ListeEcoleId);
            
            CreateTable(
                "dbo.CSGroupes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomGroupe = c.String(),
                        CSMatiereId = c.Int(nullable: false),
                        CSEnseignantId = c.Int(nullable: false),
                        CsNiveauScolaireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CSEnseignants", t => t.CSEnseignantId, cascadeDelete: true)
                .ForeignKey("dbo.CSMatieres", t => t.CSMatiereId, cascadeDelete: true)
                .ForeignKey("dbo.CSNiveauScolaires", t => t.CsNiveauScolaireId, cascadeDelete: true)
                .Index(t => t.CSMatiereId)
                .Index(t => t.CSEnseignantId)
                .Index(t => t.CsNiveauScolaireId);
            
            CreateTable(
                "dbo.CSEnseignants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        CommuneNaissance = c.String(),
                        Telephone = c.String(),
                        Adresse = c.String(),
                        PalierId = c.Int(),
                        CoursSoutien = c.Boolean(nullable: false),
                        CoursParticuliers = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paliers", t => t.PalierId)
                .Index(t => t.PalierId);
            
            CreateTable(
                "dbo.CSMatieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomMatiere = c.String(),
                        IsSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomPalier = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CSNiveauScolaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Niveau = c.String(),
                        PalierId = c.Int(nullable: false),
                        FiliereId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Filieres", t => t.FiliereId, cascadeDelete: true)
                .ForeignKey("dbo.Paliers", t => t.PalierId, cascadeDelete: true)
                .Index(t => t.PalierId)
                .Index(t => t.FiliereId);
            
            CreateTable(
                "dbo.Filieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abreviation = c.String(),
                        NomFiliere = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentGender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListeEcoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomEtablissemnt = c.String(),
                        Adresse = c.String(),
                        NumeroTelephone = c.String(),
                        Typeecole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CSNombreMatieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreMatiere = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CSTarifCoursParticuliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CSNiveauScolaireId = c.Int(nullable: false),
                        Tarif = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CSNiveauScolaires", t => t.CSNiveauScolaireId, cascadeDelete: true)
                .Index(t => t.CSNiveauScolaireId);
            
            CreateTable(
                "dbo.CSTarifCoursSoutiens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CSNiveauScolaireId = c.Int(nullable: false),
                        CSNombreMatiereID = c.Int(nullable: false),
                        Tarif = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CSNiveauScolaires", t => t.CSNiveauScolaireId, cascadeDelete: true)
                .ForeignKey("dbo.CSNombreMatieres", t => t.CSNombreMatiereID, cascadeDelete: true)
                .Index(t => t.CSNiveauScolaireId)
                .Index(t => t.CSNombreMatiereID);
            
            CreateTable(
                "dbo.CSTarificationEnseignants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeTarification = c.String(),
                        Tarif = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EPClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EPNiveauScolaireId = c.Int(nullable: false),
                        NomClasse = c.String(),
                        NomSalle = c.String(),
                        NombreMaxEleves = c.Int(nullable: false),
                        NombrePlacesDisponibles = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EPNiveauScolaires", t => t.EPNiveauScolaireId, cascadeDelete: true)
                .Index(t => t.EPNiveauScolaireId);
            
            CreateTable(
                "dbo.EPEleves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricule = c.String(),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        NomComplet = c.String(),
                        SexeEleve = c.Int(nullable: false),
                        DateNaissance = c.DateTime(nullable: false),
                        CommuneNaissance = c.String(),
                        Adresse = c.String(),
                        PrenomPere = c.String(),
                        ProfessionPere = c.String(),
                        PereVivant = c.Boolean(nullable: false),
                        NomMere = c.String(),
                        PrenomMere = c.String(),
                        ProfessionMere = c.String(),
                        MereVivante = c.Boolean(nullable: false),
                        ParentsDivorces = c.Boolean(nullable: false),
                        NomTuteur = c.String(),
                        PrenomTuteur = c.String(),
                        TelephoneTuteur = c.String(),
                        EmailTuteur = c.String(),
                        NombreFreres = c.Int(nullable: false),
                        NombreSoeurs = c.Int(nullable: false),
                        NomEnArabe = c.String(),
                        PrenomEnArabe = c.String(),
                        MaladiesChroniques = c.String(),
                        ListMaladies = c.String(),
                        Medicaments = c.String(),
                        TransporterAHopital = c.Boolean(nullable: false),
                        AcuiteVisuelle = c.String(),
                        GroupesSanguinId = c.Int(nullable: false),
                        DispenseSport = c.Boolean(nullable: false),
                        EPClasseId = c.Int(nullable: false),
                        ListeEcoleId = c.Int(nullable: false),
                        DateInscription = c.DateTime(nullable: false),
                        ModeDePaiement = c.Int(nullable: false),
                        EpTarifTransportId = c.Int(nullable: false),
                        Reduction = c.Int(nullable: false),
                        Observation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EPClasses", t => t.EPClasseId, cascadeDelete: true)
                .ForeignKey("dbo.EPTarifTransports", t => t.EpTarifTransportId, cascadeDelete: true)
                .ForeignKey("dbo.GroupesSanguins", t => t.GroupesSanguinId, cascadeDelete: true)
                .ForeignKey("dbo.ListeEcoles", t => t.ListeEcoleId, cascadeDelete: true)
                .Index(t => t.GroupesSanguinId)
                .Index(t => t.EPClasseId)
                .Index(t => t.ListeEcoleId)
                .Index(t => t.EpTarifTransportId);
            
            CreateTable(
                "dbo.EPTarifTransports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Interval = c.String(),
                        Tarif = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupesSanguins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupeSanguin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EPEnseignants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        CommuneNaissance = c.String(),
                        PalierId = c.Int(nullable: false),
                        DonneCoursSoutien = c.Boolean(nullable: false),
                        DonneCoursParticulier = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paliers", t => t.PalierId, cascadeDelete: true)
                .Index(t => t.PalierId);
            
            CreateTable(
                "dbo.EPMatieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomMatiere = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EPNiveauScolaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Niveau = c.String(),
                        PalierId = c.Int(nullable: false),
                        FiliereId = c.Int(nullable: false),
                        FraisInscription = c.Int(nullable: false),
                        TarifPaiementAnnuel = c.Int(nullable: false),
                        TarifPaiementTroisTranches = c.Int(nullable: false),
                        TarifPaiementMensuel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Filieres", t => t.FiliereId, cascadeDelete: true)
                .ForeignKey("dbo.Paliers", t => t.PalierId, cascadeDelete: true)
                .Index(t => t.PalierId)
                .Index(t => t.FiliereId);
            
            CreateTable(
                "dbo.EPModePaiements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EPPaiementEleves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EPEleveId = c.Int(nullable: false),
                        Montant = c.Single(nullable: false),
                        Reste = c.Single(nullable: false),
                        AnneeScolaireId = c.Int(nullable: false),
                        DateVersement = c.DateTime(nullable: false),
                        DateProchainPaiement = c.DateTime(nullable: false),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaireId, cascadeDelete: true)
                .ForeignKey("dbo.EPEleves", t => t.EPEleveId, cascadeDelete: true)
                .Index(t => t.EPEleveId)
                .Index(t => t.AnneeScolaireId);
            
            CreateTable(
                "dbo.EPTarifPalierEnseignants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PalierId = c.Int(nullable: false),
                        TarifParHeure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paliers", t => t.PalierId, cascadeDelete: true)
                .Index(t => t.PalierId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CSGroupeCSEleves",
                c => new
                    {
                        CSGroupe_Id = c.Int(nullable: false),
                        CSEleve_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CSGroupe_Id, t.CSEleve_Id })
                .ForeignKey("dbo.CSGroupes", t => t.CSGroupe_Id, cascadeDelete: true)
                .ForeignKey("dbo.CSEleves", t => t.CSEleve_Id, cascadeDelete: true)
                .Index(t => t.CSGroupe_Id)
                .Index(t => t.CSEleve_Id);
            
            CreateTable(
                "dbo.CSMatiereCSEleves",
                c => new
                    {
                        CSMatiere_Id = c.Int(nullable: false),
                        CSEleve_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CSMatiere_Id, t.CSEleve_Id })
                .ForeignKey("dbo.CSMatieres", t => t.CSMatiere_Id, cascadeDelete: true)
                .ForeignKey("dbo.CSEleves", t => t.CSEleve_Id, cascadeDelete: true)
                .Index(t => t.CSMatiere_Id)
                .Index(t => t.CSEleve_Id);
            
            CreateTable(
                "dbo.CSMatiereCSEnseignants",
                c => new
                    {
                        CSMatiere_Id = c.Int(nullable: false),
                        CSEnseignant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CSMatiere_Id, t.CSEnseignant_Id })
                .ForeignKey("dbo.CSMatieres", t => t.CSMatiere_Id, cascadeDelete: true)
                .ForeignKey("dbo.CSEnseignants", t => t.CSEnseignant_Id, cascadeDelete: true)
                .Index(t => t.CSMatiere_Id)
                .Index(t => t.CSEnseignant_Id);
            
            CreateTable(
                "dbo.EPEnseignantEPClasses",
                c => new
                    {
                        EPEnseignant_Id = c.Int(nullable: false),
                        EPClasse_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EPEnseignant_Id, t.EPClasse_Id })
                .ForeignKey("dbo.EPEnseignants", t => t.EPEnseignant_Id, cascadeDelete: true)
                .ForeignKey("dbo.EPClasses", t => t.EPClasse_Id, cascadeDelete: true)
                .Index(t => t.EPEnseignant_Id)
                .Index(t => t.EPClasse_Id);
            
            CreateTable(
                "dbo.EPMatiereEPEnseignants",
                c => new
                    {
                        EPMatiere_Id = c.Int(nullable: false),
                        EPEnseignant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EPMatiere_Id, t.EPEnseignant_Id })
                .ForeignKey("dbo.EPMatieres", t => t.EPMatiere_Id, cascadeDelete: true)
                .ForeignKey("dbo.EPEnseignants", t => t.EPEnseignant_Id, cascadeDelete: true)
                .Index(t => t.EPMatiere_Id)
                .Index(t => t.EPEnseignant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EPTarifPalierEnseignants", "PalierId", "dbo.Paliers");
            DropForeignKey("dbo.EPPaiementEleves", "EPEleveId", "dbo.EPEleves");
            DropForeignKey("dbo.EPPaiementEleves", "AnneeScolaireId", "dbo.AnneeScolaires");
            DropForeignKey("dbo.EPClasses", "EPNiveauScolaireId", "dbo.EPNiveauScolaires");
            DropForeignKey("dbo.EPNiveauScolaires", "PalierId", "dbo.Paliers");
            DropForeignKey("dbo.EPNiveauScolaires", "FiliereId", "dbo.Filieres");
            DropForeignKey("dbo.EPEnseignants", "PalierId", "dbo.Paliers");
            DropForeignKey("dbo.EPMatiereEPEnseignants", "EPEnseignant_Id", "dbo.EPEnseignants");
            DropForeignKey("dbo.EPMatiereEPEnseignants", "EPMatiere_Id", "dbo.EPMatieres");
            DropForeignKey("dbo.EPEnseignantEPClasses", "EPClasse_Id", "dbo.EPClasses");
            DropForeignKey("dbo.EPEnseignantEPClasses", "EPEnseignant_Id", "dbo.EPEnseignants");
            DropForeignKey("dbo.EPEleves", "ListeEcoleId", "dbo.ListeEcoles");
            DropForeignKey("dbo.EPEleves", "GroupesSanguinId", "dbo.GroupesSanguins");
            DropForeignKey("dbo.EPEleves", "EpTarifTransportId", "dbo.EPTarifTransports");
            DropForeignKey("dbo.EPEleves", "EPClasseId", "dbo.EPClasses");
            DropForeignKey("dbo.CSTarifCoursSoutiens", "CSNombreMatiereID", "dbo.CSNombreMatieres");
            DropForeignKey("dbo.CSTarifCoursSoutiens", "CSNiveauScolaireId", "dbo.CSNiveauScolaires");
            DropForeignKey("dbo.CSTarifCoursParticuliers", "CSNiveauScolaireId", "dbo.CSNiveauScolaires");
            DropForeignKey("dbo.CSEleves", "ListeEcoleId", "dbo.ListeEcoles");
            DropForeignKey("dbo.CSEleves", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.CSEleves", "CSNiveauScolaireId", "dbo.CSNiveauScolaires");
            DropForeignKey("dbo.CSGroupes", "CsNiveauScolaireId", "dbo.CSNiveauScolaires");
            DropForeignKey("dbo.CSNiveauScolaires", "PalierId", "dbo.Paliers");
            DropForeignKey("dbo.CSNiveauScolaires", "FiliereId", "dbo.Filieres");
            DropForeignKey("dbo.CSGroupes", "CSMatiereId", "dbo.CSMatieres");
            DropForeignKey("dbo.CSGroupes", "CSEnseignantId", "dbo.CSEnseignants");
            DropForeignKey("dbo.CSEnseignants", "PalierId", "dbo.Paliers");
            DropForeignKey("dbo.CSMatiereCSEnseignants", "CSEnseignant_Id", "dbo.CSEnseignants");
            DropForeignKey("dbo.CSMatiereCSEnseignants", "CSMatiere_Id", "dbo.CSMatieres");
            DropForeignKey("dbo.CSMatiereCSEleves", "CSEleve_Id", "dbo.CSEleves");
            DropForeignKey("dbo.CSMatiereCSEleves", "CSMatiere_Id", "dbo.CSMatieres");
            DropForeignKey("dbo.CSGroupeCSEleves", "CSEleve_Id", "dbo.CSEleves");
            DropForeignKey("dbo.CSGroupeCSEleves", "CSGroupe_Id", "dbo.CSGroupes");
            DropForeignKey("dbo.Communes", "WilayaId", "dbo.Wilayas");
            DropIndex("dbo.EPMatiereEPEnseignants", new[] { "EPEnseignant_Id" });
            DropIndex("dbo.EPMatiereEPEnseignants", new[] { "EPMatiere_Id" });
            DropIndex("dbo.EPEnseignantEPClasses", new[] { "EPClasse_Id" });
            DropIndex("dbo.EPEnseignantEPClasses", new[] { "EPEnseignant_Id" });
            DropIndex("dbo.CSMatiereCSEnseignants", new[] { "CSEnseignant_Id" });
            DropIndex("dbo.CSMatiereCSEnseignants", new[] { "CSMatiere_Id" });
            DropIndex("dbo.CSMatiereCSEleves", new[] { "CSEleve_Id" });
            DropIndex("dbo.CSMatiereCSEleves", new[] { "CSMatiere_Id" });
            DropIndex("dbo.CSGroupeCSEleves", new[] { "CSEleve_Id" });
            DropIndex("dbo.CSGroupeCSEleves", new[] { "CSGroupe_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.EPTarifPalierEnseignants", new[] { "PalierId" });
            DropIndex("dbo.EPPaiementEleves", new[] { "AnneeScolaireId" });
            DropIndex("dbo.EPPaiementEleves", new[] { "EPEleveId" });
            DropIndex("dbo.EPNiveauScolaires", new[] { "FiliereId" });
            DropIndex("dbo.EPNiveauScolaires", new[] { "PalierId" });
            DropIndex("dbo.EPEnseignants", new[] { "PalierId" });
            DropIndex("dbo.EPEleves", new[] { "EpTarifTransportId" });
            DropIndex("dbo.EPEleves", new[] { "ListeEcoleId" });
            DropIndex("dbo.EPEleves", new[] { "EPClasseId" });
            DropIndex("dbo.EPEleves", new[] { "GroupesSanguinId" });
            DropIndex("dbo.EPClasses", new[] { "EPNiveauScolaireId" });
            DropIndex("dbo.CSTarifCoursSoutiens", new[] { "CSNombreMatiereID" });
            DropIndex("dbo.CSTarifCoursSoutiens", new[] { "CSNiveauScolaireId" });
            DropIndex("dbo.CSTarifCoursParticuliers", new[] { "CSNiveauScolaireId" });
            DropIndex("dbo.CSNiveauScolaires", new[] { "FiliereId" });
            DropIndex("dbo.CSNiveauScolaires", new[] { "PalierId" });
            DropIndex("dbo.CSEnseignants", new[] { "PalierId" });
            DropIndex("dbo.CSGroupes", new[] { "CsNiveauScolaireId" });
            DropIndex("dbo.CSGroupes", new[] { "CSEnseignantId" });
            DropIndex("dbo.CSGroupes", new[] { "CSMatiereId" });
            DropIndex("dbo.CSEleves", new[] { "ListeEcoleId" });
            DropIndex("dbo.CSEleves", new[] { "CSNiveauScolaireId" });
            DropIndex("dbo.CSEleves", new[] { "GenderId" });
            DropIndex("dbo.Communes", new[] { "WilayaId" });
            DropTable("dbo.EPMatiereEPEnseignants");
            DropTable("dbo.EPEnseignantEPClasses");
            DropTable("dbo.CSMatiereCSEnseignants");
            DropTable("dbo.CSMatiereCSEleves");
            DropTable("dbo.CSGroupeCSEleves");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EPTarifPalierEnseignants");
            DropTable("dbo.EPPaiementEleves");
            DropTable("dbo.EPModePaiements");
            DropTable("dbo.EPNiveauScolaires");
            DropTable("dbo.EPMatieres");
            DropTable("dbo.EPEnseignants");
            DropTable("dbo.GroupesSanguins");
            DropTable("dbo.EPTarifTransports");
            DropTable("dbo.EPEleves");
            DropTable("dbo.EPClasses");
            DropTable("dbo.CSTarificationEnseignants");
            DropTable("dbo.CSTarifCoursSoutiens");
            DropTable("dbo.CSTarifCoursParticuliers");
            DropTable("dbo.CSNombreMatieres");
            DropTable("dbo.ListeEcoles");
            DropTable("dbo.Genders");
            DropTable("dbo.Filieres");
            DropTable("dbo.CSNiveauScolaires");
            DropTable("dbo.Paliers");
            DropTable("dbo.CSMatieres");
            DropTable("dbo.CSEnseignants");
            DropTable("dbo.CSGroupes");
            DropTable("dbo.CSEleves");
            DropTable("dbo.Wilayas");
            DropTable("dbo.Communes");
            DropTable("dbo.AnneeScolaires");
        }
    }
}
