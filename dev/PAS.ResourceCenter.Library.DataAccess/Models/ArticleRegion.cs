using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ArticleRegion
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public long RegionId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Region Region { get; set; }
    }
}
