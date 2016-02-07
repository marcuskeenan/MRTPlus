using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class Building
    {
        public int BuildingID { get; set; }

        [Display(Name = "Building Name")]
        public string Name { get; set; }

        [Display(Name = "Building Number")]
        public string Number { get; set; }

        [Display(Name = "Property Number")]
        public string PropertyNumber { get; set; }

        [Display(Name = "Size")]
        public Nullable<int> Size { get; set; }

        [Display(Name = "Building Type")]
        public Nullable<int> BuildingTypeID { get; set; }

        [Display(Name = "Building Usage")]
        public Nullable<int> BuildingUsageID { get; set; }

        [Display(Name = "Building Status")]
        public Nullable<int> BuildingStatusID { get; set; }

        public virtual BuildingType BuildingType { get; set; }
        public virtual BuildingUsage BuildingUsage { get; set; }
        public virtual BuildingStatus BuildingStatus { get; set; }

       // public virtual ICollection<Project> Projects { get; set; }
       // public virtual ICollection<File> Files { get; set; }
    }
}
