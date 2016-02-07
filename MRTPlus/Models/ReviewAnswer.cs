using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class ReviewAnswer
    {
        public int ReviewAnswerID { get; set; }

        public Nullable<int> ReviewID { get; set; }
        public Nullable<int> ReviewQuestionOptionID { get; set; }

        public virtual Review Review { get; set; }
        public virtual ReviewQuestionOption ReviewQuestionOption { get; set; }

        //public virtual ICollection<Review> Reviews { get; set; }

    }
}
