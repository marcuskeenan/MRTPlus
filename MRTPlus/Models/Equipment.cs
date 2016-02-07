using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRTPlus.Models;

namespace MRTPlus.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }

        public string Description { get; set; }

        public int EquipmentTypeID { get; set; }
        public int SystemID { get; set; }

        public virtual EquipmentType EquipmentType { get; set;}

        //public virtual ICollection<File> Files { get; set; }

    }
}
