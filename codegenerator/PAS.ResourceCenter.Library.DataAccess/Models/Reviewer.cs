using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Reviewer
    {
        public Reviewer()
        {
            Review = new HashSet<Review>();
        }

        public long Id { get; set; }
        public string UserId { get; set; }
        public string Biography { get; set; }
        public string Degree { get; set; }
        public bool IsActive { get; set; }
        public bool HideFromReviewerList { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UpdatedByUserId { get; set; }

        public virtual ICollection<Review> Review { get; set; }
        public virtual Users UpdatedByUser { get; set; }
        public virtual Users User { get; set; }
    }
}
