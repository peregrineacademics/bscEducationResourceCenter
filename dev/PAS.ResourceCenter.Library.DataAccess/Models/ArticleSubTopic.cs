using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ArticleSubTopic
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public long SubTopicId { get; set; }

        public virtual Article Article { get; set; }
        public virtual SubTopic SubTopic { get; set; }
    }
}
