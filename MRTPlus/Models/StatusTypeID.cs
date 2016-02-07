using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class StatusType
    {
        public int StatusTypeID { get; set; }

        [Display(Name = "Status")]
        public string Title { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}