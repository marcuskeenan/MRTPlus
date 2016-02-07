using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class ReviewType
    {
        public int ReviewTypeID { get; set; }

        [Display(Name = "Review Type")]
        public string Title { get; set; }

        public virtual ICollection<ReviewQuestion> ReviewQuestionss { get; set; }

       

        
    }
}
