using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> ReviewTypeID { get; set; }
        public Nullable<int> SMEID { get; set; }
        public Nullable<System.DateTime> ReviewDate { get; set; }
        public int Score { get; set; }


        public virtual Project Project { get; set; }
        public virtual ReviewType ReviewType { get; set; }
        //public virtual SME SME { get; set; }

        public virtual ICollection<ReviewAnswer> ReviewAnswer { get; set; }

    }
}

//O&M
//PM
//Repair
//Improvements
