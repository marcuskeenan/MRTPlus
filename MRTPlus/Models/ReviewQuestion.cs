using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class ReviewQuestion
    {


        public int ReviewQuestionID { get; set; }

        [Display(Name = "Review Question")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReviewTypeID { get; set; }

        public virtual ReviewType ReviewType { get; set; }
        public virtual ICollection<ReviewQuestionOption> ReviewQuestionOptions { get; set; }
    }
}
