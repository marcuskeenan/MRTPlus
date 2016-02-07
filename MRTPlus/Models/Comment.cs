using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MRTPlus.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRTPlus.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Text { get; set; }
        public int? ParentID { get; set; }
        public virtual Comment Parent { get; set; }
        public Nullable<System.DateTime> CommmentDate { get; set; }
        public virtual ICollection<Comment> Children { get; set; }
    }
    public class CommentParentMap : EntityTypeConfiguration<Comment>
    {
        public CommentParentMap()
        {
            HasKey(x => x.CommentID);

            Property(x => x.CommentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(255);

            HasOptional(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentID)
                .WillCascadeOnDelete(false);
        }
    }
}
