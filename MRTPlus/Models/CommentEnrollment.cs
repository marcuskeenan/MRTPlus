using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class CommentEnrollment
    {
        public int CommentEnrollmentID { get; set; }
        public int AspNetUsersId { get; set; }
        public int PortfolioID { get; set; }
        public int ProjectID { get; set; }

        public virtual ApplicationIdentity AspNetUsers { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual Project Project { get; set; }

    }
}
