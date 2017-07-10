using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Region
    {
        public Region()
        {
            ReviewRegion = new HashSet<ReviewRegion>();
            SubRegion = new HashSet<SubRegion>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<ReviewRegion> ReviewRegion { get; set; }
        public virtual ICollection<SubRegion> SubRegion { get; set; }
    }
}
