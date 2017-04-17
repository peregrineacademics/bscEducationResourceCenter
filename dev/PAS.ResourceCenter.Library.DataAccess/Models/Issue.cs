using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Article = new HashSet<Article>();
        }

        public long Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string CoverImage { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UpdatedByUserId { get; set; }

        public virtual ICollection<Article> Article { get; set; }
        public virtual Users CreatedByUser { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
