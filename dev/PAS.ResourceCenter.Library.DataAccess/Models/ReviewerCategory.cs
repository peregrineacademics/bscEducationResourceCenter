using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewerCategory
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public long Categoryid { get; set; }

        public virtual Category Category { get; set; }
        public virtual Users User { get; set; }
    }
}
