using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ArticleDiscussionQuestion
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string Question { get; set; }
        public long Ordinal { get; set; }

        public virtual Article Article { get; set; }
    }
}
