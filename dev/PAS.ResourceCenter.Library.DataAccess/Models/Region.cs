using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Region
    {
        public Region()
        {
            ArticleRegion = new HashSet<ArticleRegion>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleRegion> ArticleRegion { get; set; }
    }
}
