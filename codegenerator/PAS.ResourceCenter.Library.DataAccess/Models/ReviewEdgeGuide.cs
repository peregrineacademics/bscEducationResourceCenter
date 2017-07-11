using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewEdgeGuide
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public long EdgeGuideId { get; set; }

        public virtual EdgeGuide EdgeGuide { get; set; }
    }
}
