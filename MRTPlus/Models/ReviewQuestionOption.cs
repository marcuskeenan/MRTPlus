using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class ReviewQuestionOption
    {


        public int ReviewQuestionOptionID { get; set; }
        public int ReviewQuestionID { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }


        public virtual ReviewQuestion ReviewQuestions { get; set; }
        public virtual ICollection<ReviewAnswer> ReviewsAnswers { get; set; }

    }
}
