 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MRTPlus.Models;
using System.Data.Entity;

namespace MRTPlus.DAL
{
    public class MRTPlusInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            
            //Seed user (doesn't work
            /*
            if (!(context.Users.Any(u => u.Email== "marcus@sigwave.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { Email = "marcus@sigwave.com", EmailConfirmed = true, PhoneNumber = "0797697898" };
                userManager.Create(userToInsert, "#Sigwave98387");
            }
            */

            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppAdmin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "founder"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "founder" };

                manager.Create(user, "ChangeItAsap!");
                manager.AddToRole(user.Id, "AppAdmin");
            }
        
        
            var buildings = new List<Building>
            {
            new Building{Number="104A",Name="F&O Instrumentation & Controls"},
            new Building{Number="052",Name="Accelerator Directorate"},
            new Building{Number="053",Name="SUSB"},
            new Building{Number="002",Name="LINAC"}
            };

            buildings.ForEach(b => context.Buildings.Add(b));
            context.SaveChanges();           



            var divisions = new List<Division>
            {
            new Division{Title="F&O"},
            new Division{Title="LCLS"},
            new Division{Title="FACET"},
            new Division{Title="Photon Science"},
            new Division{Title="SSRL"}
           
            };
            divisions.ForEach(d => context.Divisions.Add(d));
            context.SaveChanges();
            /*
            var smes = new List<SME> 
            {
            new SME{Name="Marcus Keenan"},
            new SME{Name="Dan Arambula"},
            new SME{Name="Cezary Jach"},
            new SME{Name="Carlos Rodrigues"},
            new SME{Name="Ken Rubino"}
            };
            smes.ForEach(s => context.SMEs.Add(s));
            base.Seed(context);
            */
            var activitytypes = new List<ActivityType> 
            {
            new ActivityType{Title="General Plant"},
            new ActivityType{Title="Maintenance & Repair - Predictive, Preventive, or Corrective"}
            };
            activitytypes.ForEach(a => context.ActivityTypes.Add(a));
            context.SaveChanges();

            var fundingtypes = new List<FundingType> 
            {
            new FundingType{Title="Indirect"},
            new FundingType{Title="Direct"}
            };
            fundingtypes.ForEach(f => context.FundingTypes.Add(f));
            context.SaveChanges();

            var needtypes = new List<NeedType> 
            {
            new NeedType{Title="Must"},
            new NeedType{Title="Sould"}
            };
            needtypes.ForEach(n => context.NeedTypes.Add(n));
            context.SaveChanges();

            var bandrtypes = new List<BandRType> 
            {
            new BandRType{Title="Indirect"},
            new BandRType{Title="Direct"}
            };
            bandrtypes.ForEach(b => context.BandRTypes.Add(b));
            context.SaveChanges();

            var lobcategories = new List<LOBCategory> 
            {
            new LOBCategory{Title="12 KV Electrical"},
            new LOBCategory{Title="Storm Water"},
            new LOBCategory{Title="Domestic / Fire Water"}
            };
            lobcategories.ForEach(l => context.LOBCategories.Add(l));
            context.SaveChanges();


            var ifisectiontypes = new List<IFISectionType> 
            {
            new IFISectionType{Title="2.0 General Plant Projects"},
            new IFISectionType{Title="3.0 Maintenance and Repair"}
            };
            ifisectiontypes.ForEach(i => context.IFISectionTypes.Add(i));
            context.SaveChanges();

            var campusstratigies = new List<CampusStrategy> 
            {
            new CampusStrategy{Title="12 KV Electrical"},
            new CampusStrategy{Title="Roads and Mechanical Utilities"},
            new CampusStrategy{Title="Space Upgrades"},
            new CampusStrategy{Title="480 Electrical Distribution"},
            new CampusStrategy{Title="K Substations"}
            };
            campusstratigies.ForEach(c => context.CampusStrategies.Add(c));
            context.SaveChanges();

            var statustypes = new List<StatusType> 
            {
            new StatusType{Title="Active"},
            new StatusType{Title="Inactive"}
            };
            statustypes.ForEach(s => context.StatusTypes.Add(s));
            context.SaveChanges();
      
            var description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. ";
            var justification = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. ";
            var projects = new List<Project>
            {
            new Project{Title="Replace K-Substations K2, K3, and K4, Sectors 0-10 (GPP $10M)",TEC="$9,800,000",DivisionID=1,BuildingID=4,Description="Replace K-Substations K2, K3, and K4, Sectors 0-10 (GPP $10M)",Justification="K-Subs need to be replaced because the existing K-subs do not have adequate capacity to suppoer LCLS-II loads, plus switches and circuit breakers are non-functional. If this project is not done in FY16, it could be done in FY 17 with a higher risk (possible equip delay or GC issues)  of possible schedule impact to LCLS-II ", EnrollmentDate=DateTime.Parse("2015-09-01"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false},
            new Project{Title="Storm Drain Upgrade",TEC="$1,300,000",DivisionID=2,BuildingID=1,Description=description,Justification=justification, EnrollmentDate=DateTime.Parse("2015-09-02"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false},
            new Project{Title="New Building",TEC="$1,400,000",DivisionID=2,BuildingID=1,Description=description,Justification=justification, EnrollmentDate=DateTime.Parse("2015-09-03"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false},
            new Project{Title="Linac Sector 26 Controls upgrade",TEC="$2,200,000",DivisionID=3,BuildingID=1,Description="Upgrade the existing control system to allow automatic starting and stopping of the Linac LCW system. This will include the Accelerator, Klystron and Waveguide subsystems.",Justification="The existing system is prone to failures and requires 2-3 workers to stop and start effectively.", EnrollmentDate=DateTime.Parse("2015-09-04"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false},
            new Project{Title="This is a test project Title",TEC="$5,200,000",DivisionID=3,BuildingID=1,Description="This is the decription for the project",Justification="This is the amazing justification for the project", EnrollmentDate=DateTime.Parse("2015-09-05"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false},
            new Project{Title="This is a test project Title",TEC="$7,200,000",DivisionID=1,BuildingID=1,Description="This is the decription for the project",Justification="This is the amazing justification for the project", EnrollmentDate=DateTime.Parse("2015-09-06"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false},
            new Project{Title="This is a test project Title",TEC="$7,200,000",DivisionID=1,BuildingID=1,Description="This is the decription for the project",Justification="This is the amazing justification for the project", EnrollmentDate=DateTime.Parse("2015-09-06"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false},
            new Project{Title="This is a test project Title",TEC="$7,200,000",DivisionID=1,BuildingID=1,Description="This is the decription for the project",Justification="This is the amazing justification for the project", EnrollmentDate=DateTime.Parse("2015-09-06"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false},
            new Project{Title="This is a test project Title",TEC="$7,200,000",DivisionID=1,BuildingID=1,Description="This is the decription for the project",Justification="This is the amazing justification for the project", EnrollmentDate=DateTime.Parse("2015-09-06"),ActivityTypeID=1,FundingTypeID=1,Cost_K=1234,NeedTypeID=1,BandRTypeID=1,IFISectionTypeID=1,DM=true,StatusTypeID=1,CampusStrategyID=1,LOBCategoryID=1,LOBRating=6,ShovelReady=false}
            };
            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();

          var portfoliotypes = new List<PortfolioType> 
            {
            new PortfolioType{Title="Risk Reduction"},
            new PortfolioType{Title="Balanced"},
            new PortfolioType{Title="Mission Investment"},
            new PortfolioType{Title="Sustainability"}
            };
            portfoliotypes.ForEach(t => context.PortfolioTypes.Add(t));
            context.SaveChanges();


            var solutiontypes = new List<SolutionType> 
            {
            new SolutionType{Type="Primary"},
            new SolutionType{Type="Alternative"}
            };
            solutiontypes.ForEach(s => context.SolutionTypes.Add(s));
            context.SaveChanges();
            
            var solutions = new List<Solution> 
            {
            new Solution{Title="This is a solution",ProjectID=1,SolutionTypeID=1},
            new Solution{Title="This is another solution",ProjectID=1,SolutionTypeID=2},
            new Solution{Title="This is a solution",ProjectID=1,SolutionTypeID=1},
            new Solution{Title="This is a solution",ProjectID=4,SolutionTypeID=1},
            new Solution{Title="This is a solution",ProjectID=5,SolutionTypeID=1}
            };
            solutions.ForEach(s => context.Solutions.Add(s));
            context.SaveChanges();
            
            var portfolios = new List<Portfolio> 
            {
            new Portfolio{Title="Portfolio 1",FY="2016",PortfolioTypeID=1,Date=DateTime.Parse("2015-09-01")},
            new Portfolio{Title="Portfolio 2",FY="2016",PortfolioTypeID=2,Date=DateTime.Parse("2015-09-01")},
            new Portfolio{Title="Portfolio 3",FY="2016",PortfolioTypeID=3,Date=DateTime.Parse("2015-09-01")},
            new Portfolio{Title="Portfolio 4",FY="2016",PortfolioTypeID=3,Date=DateTime.Parse("2015-09-01")}
            };
            portfolios.ForEach(p => context.Portfolios.Add(p));
            context.SaveChanges();
            
            var enrollments = new List<Enrollment> 
            {
            new Enrollment{PortfolioID=1,ProjectID=1},
            new Enrollment{PortfolioID=1,ProjectID=2},
            new Enrollment{PortfolioID=1,ProjectID=3},
            new Enrollment{PortfolioID=2,ProjectID=1},
            new Enrollment{PortfolioID=2,ProjectID=2},
            new Enrollment{PortfolioID=2,ProjectID=3},
            new Enrollment{PortfolioID=3,ProjectID=3},
            new Enrollment{PortfolioID=3,ProjectID=1}
            };
            enrollments.ForEach(p => context.Enrollments.Add(p));
            context.SaveChanges();

            

            var reviewtypes = new List<ReviewType>
            {
            new ReviewType{Title="Health, Safety, & Security"},
            new ReviewType{Title="Environment"},
            new ReviewType{Title="Mission & Investment"},
            new ReviewType{Title="Cost & Schedule"}
            };
            reviewtypes.ForEach(r => context.ReviewTypes.Add(r));
            context.SaveChanges();

            var reviewquestions = new List<ReviewQuestion>
            {
            //Health Safety & Security Categories
            new ReviewQuestion{Title="Safety & Health Compliance w/ Orders, Codes,  and Laws",Description="",ReviewTypeID=1},
            new ReviewQuestion{Title="Technological Base (R&D) Develop new approaches, techniques, or methodologies",Description="",ReviewTypeID=1},
            new ReviewQuestion{Title="Exposure (Chemical and Radiological)",Description="",ReviewTypeID=1},
            new ReviewQuestion{Title="Personnel Safety",Description="",ReviewTypeID=1},
            new ReviewQuestion{Title="Fire Protection",Description="",ReviewTypeID=1},
            new ReviewQuestion{Title="Infrastructure (Security, Structures or Systems)",Description="",ReviewTypeID=1},
            //Environmental Review Categories
            new ReviewQuestion{Title="Environmental Compliance w/ Orders, Codes,  and Laws",Description="",ReviewTypeID=2},
            new ReviewQuestion{Title="Technological Base (R&D)",Description="",ReviewTypeID=2},
            new ReviewQuestion{Title="Impact to the Environment (Air, Water, Soil, Ecological Habitat)",Description="",ReviewTypeID=2},
            new ReviewQuestion{Title="Community Relations / Public Perception",Description="",ReviewTypeID=2},
            new ReviewQuestion{Title="Sustainability",Description="",ReviewTypeID=2},
            new ReviewQuestion{Title="Waste Minimization",Description="",ReviewTypeID=2},
            new ReviewQuestion{Title="Environmental Restoration",Description="",ReviewTypeID=2},
            new ReviewQuestion{Title="Infrastructure",Description="",ReviewTypeID=2},
           
            };
            reviewquestions.ForEach(r => context.ReviewQuestions.Add(r));
            context.SaveChanges();

            var reviewquestionoptions = new List<ReviewQuestionOption> 
            {
            // Health & Safety Review Category Health Safety & Security Elements
            new ReviewQuestionOption{ReviewQuestionID=1,Title="Compliant, but upcoming problems slightly likely",Score=20},
            new ReviewQuestionOption{ReviewQuestionID=1,Title="Occasional minor deviation; or not best management practice",Score=30},
            new ReviewQuestionOption{ReviewQuestionID=1,Title="Frequent minor violations",Score=40},
            new ReviewQuestionOption{ReviewQuestionID=1,Title="Frequent minor violations, with some chance of a serious violation",Score=50},
            new ReviewQuestionOption{ReviewQuestionID=1,Title="Serious violations frequent; or occasional continuing minor deviations with shutdown possible",Score=70},
            //Health & Safety Review Category Technological Base
            new ReviewQuestionOption{ReviewQuestionID=2,Title="To improve health and safety mission capability and efficiency with high R&D risk",Score=30},
            new ReviewQuestionOption{ReviewQuestionID=2,Title="In support of critical health and safety mission objectives with high R&D risk",Score=40},
            new ReviewQuestionOption{ReviewQuestionID=2,Title="To improve health and safety mission capability and efficiency with acceptable R&D risk",Score=50},
            new ReviewQuestionOption{ReviewQuestionID=2,Title="In support of critical health and safety mission objectives with acceptable R&D risk",Score=60},
            //Health & Safety Review Category Exposure
            new ReviewQuestionOption{ReviewQuestionID=3,Title="Administrative controls in place but engineering controls needed to prevent violation of exposure standards",Score=40},
            new ReviewQuestionOption{ReviewQuestionID=3,Title="Administrative controls are not effective; engineering controls or other action required preventing violation of exposure standards.",Score=60},
            new ReviewQuestionOption{ReviewQuestionID=3,Title="Potential danger to site personnel through exposure; near-term action required",Score=70},
            new ReviewQuestionOption{ReviewQuestionID=3,Title="Life- threatening situation or risk to the public possible",Score=80},
            //Health & Safety Review Category Personnel Safety
            new ReviewQuestionOption{ReviewQuestionID=4,Title="Occasional minor injury possible; or slightly likely hampered ability to respond to emergency",Score=40},
            new ReviewQuestionOption{ReviewQuestionID=4,Title="Occasional minor injury possible every year; or first aid required; or possibly hampered ability to respond to emergency",Score=50},
            new ReviewQuestionOption{ReviewQuestionID=4,Title="Possibility of less than one day of lost work time; or likely hampered ability to respond to emergency",Score=60},
            new ReviewQuestionOption{ReviewQuestionID=4,Title="Serious injury slightly likely; or ORPS P1 safety issue or possibility of greater than 1 lost work day; or highly likely hampered ability to respond to emergency",Score=70},
            new ReviewQuestionOption{ReviewQuestionID=4,Title="Life- threatening situation possible",Score=80},
            //Health & Safety Review Category Fire Protection
            new ReviewQuestionOption{ReviewQuestionID=5,Title="Property loss extremely unlikely or of trivial value",Score=20},
            new ReviewQuestionOption{ReviewQuestionID=5,Title="Standard industrial protection, acceptable risk; some property losses expected",Score=30},
            new ReviewQuestionOption{ReviewQuestionID=5,Title="Events with minor injury slightly likely",Score=40},
            new ReviewQuestionOption{ReviewQuestionID=5,Title="Events with minor injury likely",Score=50},
            new ReviewQuestionOption{ReviewQuestionID=5,Title="Serious injury moderately likely; standard industrial protection; occasional significant property loss",Score=60},
            new ReviewQuestionOption{ReviewQuestionID=5,Title="Serious injury likely; significant property losses routine",Score=70},
            new ReviewQuestionOption{ReviewQuestionID=5,Title="Fatalities possible",Score=80},
            //Heath & Safety Review Category Infrastructure
            new ReviewQuestionOption{ReviewQuestionID=6,Title="System frequently inadequate or occasional failure, numerous associated minor injuries possible or minor security issues",Score=40},
            new ReviewQuestionOption{ReviewQuestionID=6,Title="System generally inadequate or routinely in failure, numerous associated minor injuries likely or moderate security issues",Score=50},
            new ReviewQuestionOption{ReviewQuestionID=6,Title="Full system failure possible, with a small chance of  serious injury possible or significant security issues",Score=60},
            new ReviewQuestionOption{ReviewQuestionID=6,Title="Full system failure likely, with serious injury possible or serious security issues",Score=70}
            };
            reviewquestionoptions.ForEach(r => context.ReviewQuestionOptions.Add(r));
            context.SaveChanges();


            var reviews = new List<Review> 
            {
            new Review{ProjectID=1,ReviewTypeID=1,SMEID=1,Score=80,ReviewDate=DateTime.Parse("2015-09-01")},
            new Review{ProjectID=1,ReviewTypeID=2,SMEID=1,Score=50,ReviewDate=DateTime.Parse("2015-09-01")},
            new Review{ProjectID=1,ReviewTypeID=3,SMEID=1,Score=30,ReviewDate=DateTime.Parse("2015-09-01")},
            new Review{ProjectID=1,ReviewTypeID=4,SMEID=1,Score=40,ReviewDate=DateTime.Parse("2015-09-01")},
            new Review{ProjectID=2,ReviewTypeID=1,SMEID=2,Score=70,ReviewDate=DateTime.Parse("2015-09-01")},
            new Review{ProjectID=3,ReviewTypeID=1,SMEID=3,Score=20,ReviewDate=DateTime.Parse("2015-09-01")},
            new Review{ProjectID=4,ReviewTypeID=1,SMEID=4,Score=30,ReviewDate=DateTime.Parse("2015-09-01")}
            };
            reviews.ForEach(r => context.Reviews.Add(r));
            context.SaveChanges();
            
            var reviewanswers = new List<ReviewAnswer> 
            {
            new ReviewAnswer{ReviewID=1,ReviewQuestionOptionID=2},
            new ReviewAnswer{ReviewID=1,ReviewQuestionOptionID=2},
            new ReviewAnswer{ReviewID=1,ReviewQuestionOptionID=2},
            new ReviewAnswer{ReviewID=1,ReviewQuestionOptionID=2},
            new ReviewAnswer{ReviewID=1,ReviewQuestionOptionID=2},
            new ReviewAnswer{ReviewID=1,ReviewQuestionOptionID=2},
            new ReviewAnswer{ReviewID=1,ReviewQuestionOptionID=2}
            };
            reviewanswers.ForEach(r => context.ReviewAnswers.Add(r));
            context.SaveChanges();
        }
    }
}
    

