using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using MRTPlus.Models;




namespace MRTPlus.Models
{
    public class Project
    {
        
    
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "A Project Title is required")]
        [StringLength(160)]
        [Display(Name = "Project Title")]
        public string Title { get; set; }
        public string TEC { get; set; }
        
        [Display(Name = "Division")]
        public Nullable<int> DivisionID { get; set; }
        
        [Display(Name = "Building")]
        public Nullable<int> BuildingID { get; set; }
        
        [Display(Name = "Subject Mater Expert")]
        public Nullable<int> SMEID { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Description")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Justification")]
        public string Justification { get; set; }
        
        
        
        
        // new items
        public Nullable<int> ActivityTypeID { get; set; }
        
        public Nullable<int> FundingTypeID { get; set; }

        public Nullable<int> FundingSourceID { get; set; }

        public Nullable<float> Cost_K { get; set; }
        
        public Nullable<int> NeedTypeID { get; set; }
        
        public Nullable<int> BandRTypeID { get; set;}
        
        public Nullable<int> IFISectionTypeID { get; set; }

        public Nullable<float> RiskScore { get; set; }

        public Nullable<float> RiskProbability { get; set; }

        public Nullable<float> RiskConsequence { get; set; }

        public bool DM { get; set; }
        
        public Nullable<int> StatusTypeID { get; set; }
        public Nullable<int> CampusStrategyID { get; set; }
        public Nullable<int> LOBCategoryID { get; set; }
        public Nullable<int> LOBRating { get; set; }
        public bool ShovelReady { get; set; }
        //end of new



        public Nullable<System.DateTime> EnrollmentDate { get; set; }
        public Nullable<int> BudgetYear { get; set; }

        public virtual Division Division { get; set; }
        public virtual Building Building { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public virtual FundingType FundingType { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public virtual LOBCategory LOBCategory { get; set; }
        public virtual NeedType NeedType { get; set; }
        public virtual BandRType BandRType { get; set; }
        public virtual IFISectionType IFISectionType { get; set; }
        public virtual StatusType StatusType { get; set; }
        public virtual CampusStrategy CampusStrategy { get; set; }     
        //public virtual SME SME { get; set; }
        
        
        public virtual ICollection<Solution> Solutions { get; set; }
        //public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        //not sure if ReviewTupe and ReviewElement are needed here
        public virtual ICollection<ReviewType> ReviewTypes { get; set; }
        public virtual ICollection<ReviewAnswer> ReviewAnswers { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<File> Files { get; set; }
        
       
    }
}
