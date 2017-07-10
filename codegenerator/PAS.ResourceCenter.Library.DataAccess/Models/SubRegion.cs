using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class SubRegion
    {
        public SubRegion()
        {
            ReviewSubRegion = new HashSet<ReviewSubRegion>();
        }

        public long Id { get; set; }
        public long RegionId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<ReviewSubRegion> ReviewSubRegion { get; set; }
        public virtual Region Region { get; set; }
    }
}
