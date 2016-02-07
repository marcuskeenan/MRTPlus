using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class IFISectionType
    {
        public int IFISectionTypeID { get; set; }

        [Display(Name = "IFI Section Type")]
        public string Title { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}