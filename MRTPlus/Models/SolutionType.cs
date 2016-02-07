using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class SolutionType
    {
        public int SolutionTypeID { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Solution> Solutions { get; set; }

    }
}
