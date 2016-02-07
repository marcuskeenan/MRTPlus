using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class Portfolio
    {
        
        public int PortfolioID { get; set; }

        [Display(Name = "Portfolio Title")]
        public string Title { get; set; }
        public string FY { get; set; }
        public int PortfolioTypeID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        [Display(Name = "Project Type")]
        public virtual PortfolioType PortfolioType { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        //public virtual ICollection<File> Files { get; set; }
        //public virtual ICollection<Project> Projects { get; set; }
    }
}
