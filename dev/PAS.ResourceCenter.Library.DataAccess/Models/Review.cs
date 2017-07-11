using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Review
    {
        public Review()
        {
            ReviewCategory = new HashSet<ReviewCategory>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public long IssueId { get; set; }
        public string ReviewerId { get; set; }
        public string Abstract { get; set; }
        public string Summary { get; set; }
        public long GuideTypeId { get; set; }
        public long ReviewStatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UpdatedByUserId { get; set; }
        public string KeyWords { get; set; }
        public bool Migrated { get; set; }

        public virtual ICollection<ReviewCategory> ReviewCategory { get; set; }
        public virtual Users CreatedByUser { get; set; }
        public virtual GuideType GuideType { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual ReviewStatus ReviewStatus { get; set; }
        public virtual Users Reviewer { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
