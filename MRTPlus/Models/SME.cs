using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class SME
    {
        public int SMEID { get; set; }

        [Display(Name = "Subject Matter Expert")]
        public string Name { get; set; }
    }
}
