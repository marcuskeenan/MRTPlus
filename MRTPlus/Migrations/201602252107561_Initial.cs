namespace MRTPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        ActivityTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ActivityTypeID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 160),
                        TEC = c.String(),
                        DivisionID = c.Int(),
                        BuildingID = c.Int(),
                        SMEID = c.Int(),
                        Description = c.String(),
                        Justification = c.String(),
                        ActivityTypeID = c.Int(),
                        FundingTypeID = c.Int(),
                        FundingSourceID = c.Int(),
                        Cost_K = c.Single(),
                        NeedTypeID = c.Int(),
                        BandRTypeID = c.Int(),
                        IFISectionTypeID = c.Int(),
                        RiskScore = c.Single(),
                        RiskProbability = c.Single(),
                        RiskConsequence = c.Single(),
                        DM = c.Boolean(nullable: false),
                        StatusTypeID = c.Int(),
                        CampusStrategyID = c.Int(),
                        LOBCategoryID = c.Int(),
                        LOBRating = c.Int(),
                        ShovelReady = c.Boolean(nullable: false),
                        EnrollmentDate = c.DateTime(),
                        BudgetYear = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityTypeID)
                .ForeignKey("dbo.BandRTypes", t => t.BandRTypeID)
                .ForeignKey("dbo.Buildings", t => t.BuildingID)
                .ForeignKey("dbo.CampusStrategies", t => t.CampusStrategyID)
                .ForeignKey("dbo.Divisions", t => t.DivisionID)
                .ForeignKey("dbo.FundingSources", t => t.FundingSourceID)
                .ForeignKey("dbo.FundingTypes", t => t.FundingTypeID)
                .ForeignKey("dbo.IFISectionTypes", t => t.IFISectionTypeID)
                .ForeignKey("dbo.LOBCategories", t => t.LOBCategoryID)
                .ForeignKey("dbo.NeedTypes", t => t.NeedTypeID)
                .ForeignKey("dbo.StatusTypes", t => t.StatusTypeID)
                .Index(t => t.DivisionID)
                .Index(t => t.BuildingID)
                .Index(t => t.ActivityTypeID)
                .Index(t => t.FundingTypeID)
                .Index(t => t.FundingSourceID)
                .Index(t => t.NeedTypeID)
                .Index(t => t.BandRTypeID)
                .Index(t => t.IFISectionTypeID)
                .Index(t => t.StatusTypeID)
                .Index(t => t.CampusStrategyID)
                .Index(t => t.LOBCategoryID);
            
            CreateTable(
                "dbo.BandRTypes",
                c => new
                    {
                        BandRTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BandRTypeID);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.String(),
                        PropertyNumber = c.String(),
                        Size = c.Int(),
                        BuildingTypeID = c.Int(),
                        BuildingUsageID = c.Int(),
                        BuildingStatusID = c.Int(),
                    })
                .PrimaryKey(t => t.BuildingID)
                .ForeignKey("dbo.BuildingStatus", t => t.BuildingStatusID)
                .ForeignKey("dbo.BuildingTypes", t => t.BuildingTypeID)
                .ForeignKey("dbo.BuildingUsages", t => t.BuildingUsageID)
                .Index(t => t.BuildingTypeID)
                .Index(t => t.BuildingUsageID)
                .Index(t => t.BuildingStatusID);
            
            CreateTable(
                "dbo.BuildingStatus",
                c => new
                    {
                        BuildingStatusID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BuildingStatusID);
            
            CreateTable(
                "dbo.BuildingTypes",
                c => new
                    {
                        BuildingTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BuildingTypeID);
            
            CreateTable(
                "dbo.BuildingUsages",
                c => new
                    {
                        BuildingUsageID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BuildingUsageID);
            
            CreateTable(
                "dbo.CampusStrategies",
                c => new
                    {
                        CampusStrategyID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.CampusStrategyID);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        DivisionID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.DivisionID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        PortfolioID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.PortfolioID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FY = c.String(),
                        PortfolioTypeID = c.Int(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.PortfolioID)
                .ForeignKey("dbo.PortfolioTypes", t => t.PortfolioTypeID, cascadeDelete: true)
                .Index(t => t.PortfolioTypeID);
            
            CreateTable(
                "dbo.PortfolioTypes",
                c => new
                    {
                        PortfolioTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.PortfolioTypeID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileGUID = c.String(),
                        FileType = c.Int(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        PersonID = c.Int(),
                        ProjectID = c.Int(),
                        PortfolioID = c.Int(),
                        EquipmentID = c.Int(),
                        SystemNameID = c.Int(),
                        BuildingID = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Buildings", t => t.BuildingID)
                .ForeignKey("dbo.Equipments", t => t.EquipmentID)
                .ForeignKey("dbo.People", t => t.PersonID)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.SystemNames", t => t.SystemNameID)
                .Index(t => t.PersonID)
                .Index(t => t.ProjectID)
                .Index(t => t.PortfolioID)
                .Index(t => t.EquipmentID)
                .Index(t => t.SystemNameID)
                .Index(t => t.BuildingID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        EquipmentTypeID = c.Int(nullable: false),
                        SystemID = c.Int(nullable: false),
                        EquipmentType_EquimpentTypeID = c.Int(nullable: false),
                        EquipmentType_Name = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemNames",
                c => new
                    {
                        SystemNameID = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SystemNameID);
            
            CreateTable(
                "dbo.FundingSources",
                c => new
                    {
                        FundingSourceID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.FundingSourceID);
            
            CreateTable(
                "dbo.FundingTypes",
                c => new
                    {
                        FundingTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.FundingTypeID);
            
            CreateTable(
                "dbo.IFISectionTypes",
                c => new
                    {
                        IFISectionTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.IFISectionTypeID);
            
            CreateTable(
                "dbo.LOBCategories",
                c => new
                    {
                        LOBCategoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.LOBCategoryID);
            
            CreateTable(
                "dbo.NeedTypes",
                c => new
                    {
                        NeedTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.NeedTypeID);
            
            CreateTable(
                "dbo.ReviewAnswers",
                c => new
                    {
                        ReviewAnswerID = c.Int(nullable: false, identity: true),
                        ReviewID = c.Int(),
                        ReviewQuestionOptionID = c.Int(),
                        Project_ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewAnswerID)
                .ForeignKey("dbo.Reviews", t => t.ReviewID)
                .ForeignKey("dbo.ReviewQuestionOptions", t => t.ReviewQuestionOptionID)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID)
                .Index(t => t.ReviewID)
                .Index(t => t.ReviewQuestionOptionID)
                .Index(t => t.Project_ProjectID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(),
                        ReviewTypeID = c.Int(),
                        SMEID = c.Int(),
                        ReviewDate = c.DateTime(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.ReviewTypes", t => t.ReviewTypeID)
                .Index(t => t.ProjectID)
                .Index(t => t.ReviewTypeID);
            
            CreateTable(
                "dbo.ReviewTypes",
                c => new
                    {
                        ReviewTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Project_ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewTypeID)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID)
                .Index(t => t.Project_ProjectID);
            
            CreateTable(
                "dbo.ReviewQuestions",
                c => new
                    {
                        ReviewQuestionID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ReviewTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewQuestionID)
                .ForeignKey("dbo.ReviewTypes", t => t.ReviewTypeID, cascadeDelete: true)
                .Index(t => t.ReviewTypeID);
            
            CreateTable(
                "dbo.ReviewQuestionOptions",
                c => new
                    {
                        ReviewQuestionOptionID = c.Int(nullable: false, identity: true),
                        ReviewQuestionID = c.Int(nullable: false),
                        Title = c.String(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewQuestionOptionID)
                .ForeignKey("dbo.ReviewQuestions", t => t.ReviewQuestionID, cascadeDelete: true)
                .Index(t => t.ReviewQuestionID);
            
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        SolutionID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ProjectID = c.Int(),
                        SolutionTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.SolutionID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.SolutionTypes", t => t.SolutionTypeID)
                .Index(t => t.ProjectID)
                .Index(t => t.SolutionTypeID);
            
            CreateTable(
                "dbo.SolutionTypes",
                c => new
                    {
                        SolutionTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.SolutionTypeID);
            
            CreateTable(
                "dbo.StatusTypes",
                c => new
                    {
                        StatusTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.StatusTypeID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ParentID = c.Int(),
                        CommmentDate = c.DateTime(),
                        Parent_CommentID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Comments", t => t.Parent_CommentID)
                .Index(t => t.Parent_CommentID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "Parent_CommentID", "dbo.Comments");
            DropForeignKey("dbo.Projects", "StatusTypeID", "dbo.StatusTypes");
            DropForeignKey("dbo.Solutions", "SolutionTypeID", "dbo.SolutionTypes");
            DropForeignKey("dbo.Solutions", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ReviewTypes", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ReviewAnswers", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Reviews", "ReviewTypeID", "dbo.ReviewTypes");
            DropForeignKey("dbo.ReviewQuestions", "ReviewTypeID", "dbo.ReviewTypes");
            DropForeignKey("dbo.ReviewAnswers", "ReviewQuestionOptionID", "dbo.ReviewQuestionOptions");
            DropForeignKey("dbo.ReviewQuestionOptions", "ReviewQuestionID", "dbo.ReviewQuestions");
            DropForeignKey("dbo.ReviewAnswers", "ReviewID", "dbo.Reviews");
            DropForeignKey("dbo.Reviews", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "NeedTypeID", "dbo.NeedTypes");
            DropForeignKey("dbo.Projects", "LOBCategoryID", "dbo.LOBCategories");
            DropForeignKey("dbo.Projects", "IFISectionTypeID", "dbo.IFISectionTypes");
            DropForeignKey("dbo.Projects", "FundingTypeID", "dbo.FundingTypes");
            DropForeignKey("dbo.Projects", "FundingSourceID", "dbo.FundingSources");
            DropForeignKey("dbo.Files", "SystemNameID", "dbo.SystemNames");
            DropForeignKey("dbo.Files", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Files", "PortfolioID", "dbo.Portfolios");
            DropForeignKey("dbo.Files", "PersonID", "dbo.People");
            DropForeignKey("dbo.Files", "EquipmentID", "dbo.Equipments");
            DropForeignKey("dbo.Files", "BuildingID", "dbo.Buildings");
            DropForeignKey("dbo.Enrollments", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Portfolios", "PortfolioTypeID", "dbo.PortfolioTypes");
            DropForeignKey("dbo.Enrollments", "PortfolioID", "dbo.Portfolios");
            DropForeignKey("dbo.Projects", "DivisionID", "dbo.Divisions");
            DropForeignKey("dbo.Projects", "CampusStrategyID", "dbo.CampusStrategies");
            DropForeignKey("dbo.Projects", "BuildingID", "dbo.Buildings");
            DropForeignKey("dbo.Buildings", "BuildingUsageID", "dbo.BuildingUsages");
            DropForeignKey("dbo.Buildings", "BuildingTypeID", "dbo.BuildingTypes");
            DropForeignKey("dbo.Buildings", "BuildingStatusID", "dbo.BuildingStatus");
            DropForeignKey("dbo.Projects", "BandRTypeID", "dbo.BandRTypes");
            DropForeignKey("dbo.Projects", "ActivityTypeID", "dbo.ActivityTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Comments", new[] { "Parent_CommentID" });
            DropIndex("dbo.Solutions", new[] { "SolutionTypeID" });
            DropIndex("dbo.Solutions", new[] { "ProjectID" });
            DropIndex("dbo.ReviewQuestionOptions", new[] { "ReviewQuestionID" });
            DropIndex("dbo.ReviewQuestions", new[] { "ReviewTypeID" });
            DropIndex("dbo.ReviewTypes", new[] { "Project_ProjectID" });
            DropIndex("dbo.Reviews", new[] { "ReviewTypeID" });
            DropIndex("dbo.Reviews", new[] { "ProjectID" });
            DropIndex("dbo.ReviewAnswers", new[] { "Project_ProjectID" });
            DropIndex("dbo.ReviewAnswers", new[] { "ReviewQuestionOptionID" });
            DropIndex("dbo.ReviewAnswers", new[] { "ReviewID" });
            DropIndex("dbo.Files", new[] { "BuildingID" });
            DropIndex("dbo.Files", new[] { "SystemNameID" });
            DropIndex("dbo.Files", new[] { "EquipmentID" });
            DropIndex("dbo.Files", new[] { "PortfolioID" });
            DropIndex("dbo.Files", new[] { "ProjectID" });
            DropIndex("dbo.Files", new[] { "PersonID" });
            DropIndex("dbo.Portfolios", new[] { "PortfolioTypeID" });
            DropIndex("dbo.Enrollments", new[] { "ProjectID" });
            DropIndex("dbo.Enrollments", new[] { "PortfolioID" });
            DropIndex("dbo.Buildings", new[] { "BuildingStatusID" });
            DropIndex("dbo.Buildings", new[] { "BuildingUsageID" });
            DropIndex("dbo.Buildings", new[] { "BuildingTypeID" });
            DropIndex("dbo.Projects", new[] { "LOBCategoryID" });
            DropIndex("dbo.Projects", new[] { "CampusStrategyID" });
            DropIndex("dbo.Projects", new[] { "StatusTypeID" });
            DropIndex("dbo.Projects", new[] { "IFISectionTypeID" });
            DropIndex("dbo.Projects", new[] { "BandRTypeID" });
            DropIndex("dbo.Projects", new[] { "NeedTypeID" });
            DropIndex("dbo.Projects", new[] { "FundingSourceID" });
            DropIndex("dbo.Projects", new[] { "FundingTypeID" });
            DropIndex("dbo.Projects", new[] { "ActivityTypeID" });
            DropIndex("dbo.Projects", new[] { "BuildingID" });
            DropIndex("dbo.Projects", new[] { "DivisionID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Comments");
            DropTable("dbo.StatusTypes");
            DropTable("dbo.SolutionTypes");
            DropTable("dbo.Solutions");
            DropTable("dbo.ReviewQuestionOptions");
            DropTable("dbo.ReviewQuestions");
            DropTable("dbo.ReviewTypes");
            DropTable("dbo.Reviews");
            DropTable("dbo.ReviewAnswers");
            DropTable("dbo.NeedTypes");
            DropTable("dbo.LOBCategories");
            DropTable("dbo.IFISectionTypes");
            DropTable("dbo.FundingTypes");
            DropTable("dbo.FundingSources");
            DropTable("dbo.SystemNames");
            DropTable("dbo.People");
            DropTable("dbo.Equipments");
            DropTable("dbo.Files");
            DropTable("dbo.PortfolioTypes");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Divisions");
            DropTable("dbo.CampusStrategies");
            DropTable("dbo.BuildingUsages");
            DropTable("dbo.BuildingTypes");
            DropTable("dbo.BuildingStatus");
            DropTable("dbo.Buildings");
            DropTable("dbo.BandRTypes");
            DropTable("dbo.Projects");
            DropTable("dbo.ActivityTypes");
        }
    }
}
