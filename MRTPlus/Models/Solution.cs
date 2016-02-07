using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class Solution
    {
        public int SolutionID { get; set; }

        [Display(Name = "Solution")]
        public string Title { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> SolutionTypeID { get; set; }

        public virtual Project Project { get; set; }
        public virtual SolutionType SolutionType { get; set; }

    }
}
