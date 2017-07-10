using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class DiscussionQuestion
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public string Question { get; set; }
        public long Ordinal { get; set; }

        public virtual Review Review { get; set; }
    }
}
