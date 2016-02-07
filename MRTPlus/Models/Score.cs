using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int ReviewDataID { get; set; }
        public float score { get; set; }
    }
}
