using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ArticleActivity
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string Activity { get; set; }
        public long Ordinal { get; set; }

        public virtual Article Article { get; set; }
    }
}
