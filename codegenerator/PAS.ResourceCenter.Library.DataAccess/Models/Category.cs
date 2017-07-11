using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            ReviewCategory = new HashSet<ReviewCategory>();
            ReviewerCategory = new HashSet<ReviewerCategory>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long GroupId { get; set; }
        public long ParentId { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<ReviewCategory> ReviewCategory { get; set; }
        public virtual ICollection<ReviewerCategory> ReviewerCategory { get; set; }
    }
}
