using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewSubRegion
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public long SubRegionId { get; set; }

        public virtual Review Review { get; set; }
        public virtual SubRegion SubRegion { get; set; }
    }
}
