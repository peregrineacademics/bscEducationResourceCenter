using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ArticleSector
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public long SectorId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
