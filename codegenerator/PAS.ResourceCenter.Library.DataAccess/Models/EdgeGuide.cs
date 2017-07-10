using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class EdgeGuide
    {
        public EdgeGuide()
        {
            ReviewEdgeGuide = new HashSet<ReviewEdgeGuide>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ReviewEdgeGuide> ReviewEdgeGuide { get; set; }
    }
}
