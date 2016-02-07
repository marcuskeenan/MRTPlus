using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class ReviewElement
    {
        

        public int ReviewElementID { get; set; }
        public int ReviewCategoryID { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }

        
        public virtual ReviewCategory ReviewCategory { get; set; }
        public virtual ICollection<ReviewData> ReviewsDatas { get; set; }

    }
}
