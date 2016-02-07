using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class ReviewData
    {
        public int ReviewDataID { get; set; }
        
        public Nullable<int> ReviewID { get; set; }
        public Nullable<int> ReviewElementID { get; set; }
    
        public virtual Review Review { get; set; }
        public virtual ReviewElement ReviewElement { get; set; }

        //public virtual ICollection<Review> Reviews { get; set; }

    }
}
