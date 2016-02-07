using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MRTPlus.Models;

namespace MRTPlus.DAL
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

        public System.Data.Entity.DbSet<MRTPlus.Models.ActivityType> ActivityTypes { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.Building> Buildings { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.BuildingStatus> BuildingStatuses { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.BuildingType> BuildingTypes { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.BuildingUsage> BuildingUsages { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.Portfolio> Portfolios { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.PortfolioType> PortfolioTypes { get; set; }


        public System.Data.Entity.DbSet<MRTPlus.Models.BandRType> BandRTypes { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.CampusStrategy> CampusStrategies { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.Division> Divisions { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.Enrollment> Enrollments { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.FundingType> FundingTypes { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.FundingSource> FundingSources { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.IFISectionType> IFISectionTypes { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.LOBCategory> LOBCategories { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.NeedType> NeedTypes { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.ReviewType> ReviewTypes { get; set; }

        //public System.Data.Entity.DbSet<MRTPlus.Models.ReviewCategory> ReviewCategories { get; set; }

        // public System.Data.Entity.DbSet<MRTPlus.Models.ReviewElement> ReviewElements { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.ReviewQuestion> ReviewQuestions { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.ReviewQuestionOption> ReviewQuestionOptions { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.ReviewAnswer> ReviewAnswers { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.Review> Reviews { get; set; }

        //public System.Data.Entity.DbSet<MRTPlus.Models.ReviewData> ReviewDatas { get; set; }

        //public System.Data.Entity.DbSet<MRTPlus.Models.SME> SMEs { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.Solution> Solutions { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.SolutionType> SolutionTypes { get; set; }

        public System.Data.Entity.DbSet<MRTPlus.Models.StatusType> StatusTypes { get; set; }


        public System.Data.Entity.DbSet<MRTPlus.Models.Comment> Comment { get; set; }

        public System.Data.Entity.DbSet<File> Files { get; set; }

    }
}