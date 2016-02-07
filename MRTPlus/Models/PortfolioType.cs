using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;



namespace MRTPlus.Models
{
    public class PortfolioType
    {
        [Display(Name = "Portfolio Title")]
        public int PortfolioTypeID { get; set; }
        public string Title { get; set; }
        
    }
}
