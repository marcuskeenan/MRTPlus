using System;
using System.ComponentModel.DataAnnotations;


namespace MRTPlus.Models
{
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public string FileGUID { get; set; }
        public FileType FileType { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        //public FileType FileType { get; set; }
        public Nullable<int> PersonID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> PortfolioID { get; set; }
        public Nullable<int> EquipmentID { get; set; }
        public Nullable<int> SystemNameID { get; set; }
        public Nullable<int> BuildingID { get; set; }

        public virtual Person Person { get; set; }
        public virtual Project Project { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual SystemName SystemName { get; set; }
        public virtual Building Building { get; set; }


    }
}