using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class ActivityType
    {
        public int ActivityTypeID { get; set; }

        [Display(Name = "Activity Type")]
        public string Title { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
