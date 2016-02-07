using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class Division
    {       
        public int DivisionID { get; set; }
        
        [Display(Name = "Division")]
        public string Title { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
